using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using senai_spmg_webAPI.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_spmg_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepository srRepository { get; set; }
        public LoginController()
        {
            srRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Login(User login)
        {
            User searchUser = srRepository.Login(login.Email, login.Passwd);

            if (searchUser.Email == null)
            {
                return NotFound("Email inválido!");
            }
            if (searchUser.Passwd == null)
            {
                return NotFound("Senha inválida!");
            }

            var myClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, searchUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, searchUser.IdUser.ToString()),
                new Claim(ClaimTypes.Role, searchUser.IdUserType.ToString()),
                new Claim("role", searchUser.IdUserType.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("13Ma01ECAErOl21S"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var myToken = new JwtSecurityToken(
                issuer: "senai_spmg_webAPI",
                audience: "senai_spmg_webAPI",
                claims: myClaims,
                expires: DateTime.Now.AddMinutes(59),
                signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(myToken)
            });
        }
    }
}
