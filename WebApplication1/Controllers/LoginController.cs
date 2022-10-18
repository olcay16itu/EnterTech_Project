using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_DataAccess;
using Project_Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace WebApplication1.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            private readonly ApplicationDbContext _context;

            public LoginController(IConfiguration configuration,ApplicationDbContext context)
            {
                _configuration = configuration;
                _context = context;
            }

            [HttpPost]
            [Route("login")]
            public IActionResult Login([FromBody] LoginDTO user)
            {
            var id = _context.Kullanicis.SingleOrDefault(x => x.KullaniciRegisterID == user.KullaniciRegisterID);
            var sifre = _context.Kullanicis.SingleOrDefault(x => x.KullaniciSifre == user.KullaniciSifre);

            if (!(id == null) && !(sifre == null))
            {
                var jwtToken = GenerateJwtToken(user);
                Response.Cookies.Append("jwt", jwtToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                return Ok(jwtToken);
            }
                return BadRequest("Invalid user");
            }
            

        private TokenValidationParameters GetTokenValidationParameters()
            {
                var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

                return new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                    ValidIssuers = new string[] { _configuration["Jwt:Secret"] },
                    ValidAudiences = new string[] { _configuration["Jwt:Secret"] },
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true
                };
            }

            private string GenerateJwtToken(LoginDTO user)
            {
                var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

                var claims = new Claim[] {
                    new Claim(ClaimTypes.Name,user.KullaniciRegisterID),
                };

                var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Secret"],
                      _configuration["Jwt:Secret"],
                      claims,
                      expires: DateTime.Now.AddDays(7),
                      signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                
                return jwt_token ;
            }
        }
    }
