using AutoMapper.Internal;
using DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using BL.Managers.UserManager;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using BL.DTOClass.AuthDTO;

namespace BL
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<CustomeUser> _userManager;
        private readonly ICustomerRepo _customerRepo;
        private readonly IProviderRepo _providerRepo;
        private readonly IServiceRepo _serviceRepo;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;
        private readonly MailSetting _mailSetting;
        private readonly ICustomUserManager _customUserManager ;

        public AuthServices(UserManager<CustomeUser> userManager, ICustomerRepo customerRepo, IMapper mapper, IProviderRepo providerRepo, IServiceRepo serviceRepo, IOptions<JWT> jwt, IOptions<MailSetting> MailSetting, ICustomUserManager customUserManager)
        {
            _userManager = userManager;
            _customerRepo = customerRepo;
            _mapper = mapper;
            _providerRepo = providerRepo;
            _serviceRepo = serviceRepo;
            _jwt = jwt.Value;
            _mailSetting = MailSetting.Value;
            _customUserManager = customUserManager;
        }

        public async Task<LoginToken> LoginAsync(LoginRead model)
        {
            var user = await _userManager.FindByNameAsync (model.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new LoginToken { Message = "Username or Password is incorrect!" };
            }

            var isLocked = await _userManager.IsLockedOutAsync(user);
            if (isLocked)
            {
                return new LoginToken { Message = "You're Locked out." };
            }
            
            var result = await CreateTokenAsync(user);
            _customUserManager.UserRefreshToken();
            
            RefreshToken UserrefreshToken;
            string refreshToken;
            DateTime RefershTokenExpirOn;

            if (user.RefreshTokens.Any(R => R.IsActive))
            {
                UserrefreshToken = (user.RefreshTokens.First(R => R.IsActive));
                refreshToken = UserrefreshToken.Token;
                RefershTokenExpirOn = UserrefreshToken.ExpirationOn;
            }
            else 
            {
                UserrefreshToken = CreateRefreshToken();
                user.RefreshTokens.Add(UserrefreshToken);
                await _userManager.UpdateAsync(user);

                RefershTokenExpirOn = UserrefreshToken.ExpirationOn;
                refreshToken = UserrefreshToken.Token;
            }
            
            result.RefreshToken = refreshToken;
            result.RefershTokenExpirOn = RefershTokenExpirOn;
            return result ;
        }
  
        public async Task<LoginToken> CustomerRegisterAsync(SignUpCustomer model)
        {

            var usermodel = _mapper.Map<UserSignUp>(model);
            usermodel.Type = UserTypes.Customer;
            usermodel.Role = "customer";
            var result = (await UserRegisterAsync(usermodel));

            if (result.user is null)
            {
                return new LoginToken{ Message = result.Message };
            }

            var user = result.user;
            Customer customer = new Customer
            {
                UserId = user.Id,
                user = user
            };
            _customerRepo.Add(customer);
            user.customer = customer;
            _customerRepo.SaveChange();

            LoginToken token = await CreateTokenAsync(user);

            var RefreshToken = CreateRefreshToken();
            user.RefreshTokens.Add(RefreshToken);
            await _userManager.UpdateAsync(user);
            token.RefreshToken = RefreshToken.Token;
            token.RefershTokenExpirOn = RefreshToken.ExpirationOn;

            return token;

        }

        public async Task<LoginToken> ProviderRegisterAsync(SignUpProvider model)
        {

            var usermodel = _mapper.Map<UserSignUp>(model);
            usermodel.Type = UserTypes.Provider;
            usermodel.Role = "Customer";


            var result = (await UserRegisterAsync(usermodel));
            if (result.user is null)
            {
                return new LoginToken
                {
                    Message = result.Message
                };
            }
            var user = result.user;

            var service = _serviceRepo.GetById(model.ServiceId);
            if(service is null)
            {
                return new LoginToken
                {
                    Message = " Service is null"
                };
            }

            Provider provider = new Provider
            {
                UserId = user.Id,
                user = user,
                ServiceId = model.ServiceId,
                service = service,
                sammary = model.sammary
            };
            _providerRepo.Add(provider);
            user.provider = provider;
            _providerRepo.SaveChange();

            LoginToken token = await CreateTokenAsync(user);

            var RefreshToken = CreateRefreshToken();
            user.RefreshTokens.Add(RefreshToken);
            await _userManager.UpdateAsync(user);
            token.RefreshToken = RefreshToken.Token;
            token.RefershTokenExpirOn = RefreshToken.ExpirationOn;

            return token;
        }

        public async Task<LoginToken> RefreshTokenAsync(string refreshToken)
        {
            _customUserManager.UserRefreshToken();
            
            var user = await _userManager.Users.SingleOrDefaultAsync(R=>R.RefreshTokens.Any(r=>r.Token==refreshToken));
            if (user==null)
            {
                return new LoginToken { Message = "invalid token" };
            }

            var RefreshToken = user.RefreshTokens.Single(r => r.Token == refreshToken);
            if (!RefreshToken.IsActive )
            {
                return new LoginToken { Message = "invalid token" };
            }

            RefreshToken.ExpirationOn = RefreshToken.ExpirationOn.AddHours(2);
            await _userManager.UpdateAsync(user);

            var result =await CreateTokenAsync(user);
            result.RefershTokenExpirOn = RefreshToken.ExpirationOn;
            result.RefreshToken = RefreshToken.Token;

            return result;

        }

        public async Task<bool> RevokeTokenAsync(string refreshToken)
        {
            _customUserManager.UserRefreshToken();

            var user = await _userManager.Users.SingleOrDefaultAsync(R => R.RefreshTokens.Any(r => r.Token == refreshToken));
            if (user == null)
            {
                return false;
            }

            var RefreshToken = user.RefreshTokens.Single(r => r.Token == refreshToken);
            if (!RefreshToken.IsActive)
            {
                return false;
            }

            RefreshToken.RevokedOn = DateTime.Now;
            await _userManager.UpdateAsync(user);
            return true;

        }

        public async Task SendingEmail(string mailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSetting.Email),
                Subject = subject,
            };
            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();
            builder.HtmlBody = body;

            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSetting.Name, _mailSetting.Email));

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", _mailSetting.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSetting.Email, _mailSetting.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }

        public async Task<bool> IsPasswordCorrect(isPasswordCorrect model)
        {
            if (model == null)
            {
                return false;
            }

            var user = await GetCustomeUser(model.Type, model.Id);
            if (user != null)
            {
                return await _userManager.CheckPasswordAsync(user, model.Password);
            }

            return false;
        }

        public async Task<bool> ChangePassword(ChangePassword model)
        {
            if (model == null)
            {
                return false;
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return false;
            }

            var user = await GetCustomeUser(model.Type, model.Id);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        private async Task <CustomeUser> GetCustomeUser(int Type , Guid Id)
        {
            if (Type == 0)
            {
                var user = await _userManager.FindByIdAsync(_customerRepo.GetById(Id).UserId);
                return user;
            }

            if (Type == 1)
            {
                var user = await _userManager.FindByIdAsync(_providerRepo.GetById(Id).UserId);
                return user;
            }
            return new CustomeUser { };
        }

        private async Task<LoginToken> CreateTokenAsync(CustomeUser user)
        {
            var UserClaims = await _userManager.GetClaimsAsync(user);

            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwt.Key));

            var credintial = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
            claims: UserClaims,
            expires: DateTime.Now.AddMinutes(_jwt.DurationInMinutes),
            notBefore: DateTime.Now,
            signingCredentials: credintial);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new LoginToken
            {
                Token = tokenHandler.WriteToken(jwt),
                ExpirOn = DateTime.Now.AddMinutes(_jwt.DurationInMinutes),
            };

        }

        private async Task<UserSignUpRetun> UserRegisterAsync(UserSignUp model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new UserSignUpRetun { Message = "Email is already registered!" };
            }

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                return new UserSignUpRetun { Message = "Username is already registered!" };
            }

            var user = _mapper.Map<CustomeUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, model.Role),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            await _userManager.AddClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new UserSignUpRetun { Message = errors };
            }
            return new UserSignUpRetun { user = user };

        }

        private RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpirationOn = DateTime.Now.AddDays(10),
                CreationOn = DateTime.Now
            };
        }


    }
}
