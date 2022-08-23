using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ROS.Core.Entities;
using ROS.Core.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ROS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserRepository userRepository;
        public LoginController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(403)]




        [HttpPost]
        public IActionResult Post(User user)
        {
            var authUser = userRepository.FindByUserName(user.Email,user.Password);
            if (authUser != null)
            {
                var jwtToken = GenerateJWTToken(authUser.Email, authUser.Role.ToString());
                return Ok(new { Profile = authUser, Token = jwtToken });
            }
            else
                return Unauthorized("Login Failed");
        }
        private string GenerateJWTToken(string userName, string role)
        {
            string jwtToken = string.Empty;

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my application secret"));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.Role, role));

            var token = new JwtSecurityToken("myrestuarantweb.com"
                                            , "myrestuarantweb.com"
                                            , claims
                                            , expires: DateTime.Now.AddDays(7)
                                            , signingCredentials: credentials);

            jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

    }

}




