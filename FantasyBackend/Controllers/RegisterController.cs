using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FantasyBackend.DbContextFantasy;
using FantasyBackend.Model;
using FantasyBackend.Repostitory;
using FantasyBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FantasyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        RegisterService rs;

        public RegisterController(FantasyCon context, IConfiguration configuration)
        {
            _configuration = configuration;
            rs = new RegisterService(context);
        }
        
        [HttpPost("add")]
        public Dictionary<string, object> addUser([FromBody] Register payload)
        {
            return this.rs.add(payload);
        }
        
        [HttpPost("login")]
        public object Login([FromBody] Login l)
        {
            Register resp = rs.Login(l);
            if (resp == null)
            {
                return Unauthorized();
            }
            else
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier as string, resp.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddYears(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
        }
    }
}
