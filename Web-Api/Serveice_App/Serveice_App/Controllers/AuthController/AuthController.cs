using BL;
using BL.DTO.AuthDTO;
using BL.DTOClass.AuthDTO;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;

namespace Serveice_App.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthContollerUnitOfWork _unitOfWork;

        public AuthController(IAuthContollerUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("customer-register")]
        public async Task<IActionResult> CustomerRegisterAsync(SignUpCustomer model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.AuthServices.CustomerRegisterAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }

            var user = await _unitOfWork.UserManager.FindByNameAsync(model.UserName);
            sendConfirmEmail(user);

            return Ok(result);
        }


        [HttpPost("Provider-register")]
        public async Task<IActionResult> ProviderRegisterAsync(SignUpProvider model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.AuthServices.ProviderRegisterAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }
            var user = await _unitOfWork.UserManager.FindByNameAsync(model.UserName);
            sendConfirmEmail(user);

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LogInAsync(LoginRead model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.AuthServices.LoginAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }   

            return Ok(result);
        }

        [HttpGet("Logout")]
        public async Task LogOutAsync()
        {
            await RevokeToken();
            await _unitOfWork.SignInManager.SignOutAsync();

        }

        [HttpPost("refreshtoken")]
        public async Task<LoginToken> RefreshTokenAsync([FromBody]string refreshtoken)
        {

            if (refreshtoken == null)
            {
                return new LoginToken { Message = "invalid token" };
            }

            var result = await _unitOfWork.AuthServices.RefreshTokenAsync(refreshtoken);
            if (result.Token == null)
            {
                return new LoginToken { Message = "invalid token" };
            }

            return result;
        }


        [HttpPost("forgerPassword")]
        public async Task<ActionResult> ForgerPassword(ForgetPassword model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("invalid Email");
            }
            var token = await _unitOfWork.UserManager.GeneratePasswordResetTokenAsync(user);

            var filePath = $"{Directory.GetCurrentDirectory()}\\Email.html";
            var str = new StreamReader(filePath);
            var mailText = str.ReadToEnd();
            str.Close();

            //var confirmationLink = Url.Action(nameof(model.Url), "Auth", new { token, email = user.Email }, Request.Scheme);
            var param = new Dictionary<string, string?>
            {
                {"token", token },
                {"email", user.Email }
            };
            var confirmationLink = QueryHelpers.AddQueryString(model.Url, param);

            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email).Replace("[Link]", confirmationLink);

            await _unitOfWork.AuthServices.SendingEmail(user.Email, "Welcome to our Website", mailText);
            return Ok(new { link = confirmationLink });

        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("invalid user");
            }

            if(model.Password != model.ConfirmPassword)
            {
                BadRequest("invalid password");
            }

            var result = await _unitOfWork.UserManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return  Ok();
        }

        [HttpPost("isPasswordCorrect")]
        public async Task<bool> IsPasswordCorrect(isPasswordCorrect model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            return await _unitOfWork.AuthServices.IsPasswordCorrect(model);
        }

        [HttpPost("ChangePassword")]
        public async Task<bool> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            return await _unitOfWork.AuthServices.ChangePassword(model);

        }

        [HttpGet("GetLoggedInUser")]
        [Authorize]
        public async Task<ActionResult<logedUser>> GetLoggedInUser()
        {
            var user = await _unitOfWork.UserManager.GetUserAsync(User);
            
            var result = new logedUser
            {
                Type = user.Type,
                Name = user.Fname + " " + user.Lname,
            };

            if (user.Type == UserTypes.Customer)
            {
                result.Id = _unitOfWork.CustomerManager.GetCustomerByUserId(user.Id).id;
            }
            if(user.Type == UserTypes.Provider)
            {
                result.Id = _unitOfWork.ProviderManger.GetProviderByUserId(user.Id).id;
            }

            return result;
        }

        private async Task<IActionResult> RevokeToken()
        {
            var token = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _unitOfWork.AuthServices.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }

        private void sendConfirmEmail(CustomeUser user)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Email.html";
            var str = new StreamReader(filePath);
            var mailText = str.ReadToEnd();
            str.Close();
            
            var token = _unitOfWork.UserManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);

            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email).Replace("[Link]", confirmationLink);

            _unitOfWork.AuthServices.SendingEmail(user.Email, "Welcome to our Website", mailText);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest();

            var result = await _unitOfWork.UserManager.ConfirmEmailAsync(user, token);
            return Ok(result.Succeeded ? "ConfirmEmail" : "Error");
        }

    }
}
