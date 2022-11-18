using BL.DTOClass.AuthDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAuthServices
    {
        public Task<LoginToken> CustomerRegisterAsync(SignUpCustomer model);
        public Task<LoginToken> ProviderRegisterAsync(SignUpProvider model);
        public Task<LoginToken> LoginAsync(LoginRead model);
        public Task<LoginToken> RefreshTokenAsync(string refreshToken);
        public Task<bool> RevokeTokenAsync(string refreshToken);
        public Task SendingEmail(string mailTo, string subject, string body);
        public Task<bool> IsPasswordCorrect(isPasswordCorrect model);
        public Task<bool> ChangePassword(ChangePassword model);
    }
}
