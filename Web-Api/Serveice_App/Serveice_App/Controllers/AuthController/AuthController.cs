using BL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Serveice_App.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly UserManager<CustomeUser> _userManager;
        private readonly SignInManager<CustomeUser> _signInManager;

        public AuthController(IAuthServices authServices, UserManager<CustomeUser> userManager,SignInManager<CustomeUser> signInManager )
        {
            _authServices = authServices;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("customer-register")]
        public async Task<IActionResult> CustomerRegisterAsync(SignUpCustomer model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authServices.CustomerRegisterAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefershTokenExpirOn);

            var user = await _userManager.FindByNameAsync(model.UserName);
            sendConfirmEmail(user);

            return Ok(result);
        }


        [HttpPost("Provider-register")]
        public async Task<IActionResult> ProviderRegisterAsync(SignUpProvider model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authServices.ProviderRegisterAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefershTokenExpirOn);

            var user = await _userManager.FindByNameAsync(model.UserName);
            sendConfirmEmail(user);

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LogInAsync(LoginRead model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authServices.LoginAsync(model);
            if (result.Message != null)
            {
                return BadRequest(result.Message);
            }

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefershTokenExpirOn);


            return Ok(result);
        }

        [HttpGet("Logout")]
        public async Task LogOutAsync()
        {
            await RevokeToken();
            await _signInManager.SignOutAsync();

        }

        [HttpGet("refreshtoken")]
        public async Task<IActionResult> RefreshTokenAsync()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (refreshToken == null)
            {
                return BadRequest();
            }

            var result = await _authServices.RefreshTokenAsync(refreshToken);
            if (result.Token == null)
            {
                return BadRequest(result.Message);
            }

            SetRefreshTokenInCookie(result.RefreshToken, result.RefershTokenExpirOn);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("revokeToken")]
        public async Task<IActionResult> RevokeToken()
        {
            var token = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authServices.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }

        [HttpGet("forgerPassword")]
        public async Task<ActionResult> ForgerPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("invalid Email");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var filePath = $"{Directory.GetCurrentDirectory()}\\Email.html";
            var str = new StreamReader(filePath);
            var mailText = str.ReadToEnd();
            str.Close();

            var confirmationLink = Url.Action(nameof(ResetPassword), "Auth", new { token, email = user.Email }, Request.Scheme);

            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email).Replace("[Link]", confirmationLink);

            await _authServices.SendingEmail(user.Email, "Welcome to our Website", mailText);
            return Ok();

        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("invalid user");
            }

            if(model.Password != model.ConfirmPassword)
            {
                BadRequest("invalid password");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return  Ok();
        }

        [HttpGet("getdata")]
        [Authorize]
        public async Task<ActionResult<string>> GetLoggedInUser()
        {
            var user = await _userManager.GetUserAsync(User);

            return user.Id;
        }

        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }


        private void sendConfirmEmail(CustomeUser user)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Email.html";
            var str = new StreamReader(filePath);
            var mailText = str.ReadToEnd();
            str.Close();
            
            var token =  _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);

            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email).Replace("[Link]", confirmationLink);

            _authServices.SendingEmail(user.Email, "Welcome to our Website", mailText);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return Ok(result.Succeeded ? "ConfirmEmail" : "Error");
        }

    }
}
