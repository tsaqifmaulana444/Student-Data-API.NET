using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("Login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (username == "Admin" && password == "123456")
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("login_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            //foreach (var userRole in userRoles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            //}

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        else
        {
            return Ok(new
            {
                token = "",
                expiration = ""
            });
        }

    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}