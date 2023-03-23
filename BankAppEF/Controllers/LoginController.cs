using BankApp.Entities.Model;
using BankAppEF.Datalayer.Interface;
using BankAppEF.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private LoginModel login_user;
        private readonly ICustomerDTO _customerDTO;
        public LoginController(IConfiguration configuration, ICustomerDTO customerDTO)
        {
            _configuration = configuration;
            _customerDTO = customerDTO;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                IActionResult response = Unauthorized();
                var user = await AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }

                return response;
            }
            catch (Exception ex)
            {

                return BadRequest("Not Found!");
            }
        }

        private string GenerateJSONWebToken(LoginModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] 
            {
                new Claim("Email", userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials) ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<LoginModel> AuthenticateUser(LoginModel login)
        {
            try
            {
                IEnumerable<CustomerModel> user = await _customerDTO.GetCustomerDl();
                if (login.Email == user.FirstOrDefault(u => u.Email == login.Email).Email)
                {

                    login_user = new LoginModel { Email = user.FirstOrDefault(ue => ue.Email ==login.Email).Email, Password = user.FirstOrDefault(up =>up.Password == login.Password).Password };
                }
                if (login_user != null)
                {
                    return login_user;

                }
                return null;
            }
            catch (Exception ex)
            {
                return new LoginModel();
            }
        }
    }
}
