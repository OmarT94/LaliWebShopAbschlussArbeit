using Lali.Common;
using Lali.DataAccess;
using LaliWebShop.Api.Helper;
using LaliWebShop.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LaliWebShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationBenutzer> _signInManager;
        private readonly UserManager<ApplicationBenutzer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly APISettings _aPISettings;

        public AccountController(
             UserManager<ApplicationBenutzer> userManager,
             SignInManager<ApplicationBenutzer> signInManager,
             RoleManager<IdentityRole> roleManager,
            IOptions<APISettings> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _aPISettings = options.Value;
        }
    
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto signUpRequestDto)
        {
            if(signUpRequestDto==null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var benutzer = new ApplicationBenutzer
            {
                UserName = signUpRequestDto.Email,
                Email = signUpRequestDto.Email,
                Name = signUpRequestDto.Name,
                Vorname = signUpRequestDto.Vorname,
                PhoneNumber = signUpRequestDto.HandyNummer,
                EmailConfirmed=true,
            };

            var result = await _userManager.CreateAsync(benutzer,signUpRequestDto.Passwort);
            if (!result.Succeeded)
            {
                return BadRequest(new SignUpResponseDto()
                {
                    IstRegisterationErfolgreich=false,
                    Errors=result.Errors.Select(u=>u.Description)

                });
            }
            var roleResult = await _userManager.AddToRoleAsync(benutzer, SD.Role_Customer);
            if (!roleResult.Succeeded)
            {
                return BadRequest(new SignUpResponseDto()
                {
                    IstRegisterationErfolgreich = false,
                    Errors = roleResult.Errors.Select(u => u.Description)

                });
            }
            return StatusCode(201);

           
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            if (signInRequestDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }


            var result = await _signInManager.PasswordSignInAsync(signInRequestDto.BenutzerName, signInRequestDto.Passwort, false, false);
            if (result.Succeeded)
            {
                var benutzer = await _userManager.FindByNameAsync(signInRequestDto.BenutzerName);
                if (benutzer == null)
                {
                    return Unauthorized(new SignInResponseDto
                    {
                        IsAuthErfolgreich = false,
                        ErrorMessage = "Ungültige Authentifizierung"
                    });
                }

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(benutzer);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new SignInResponseDto()
                {
                    IsAuthErfolgreich = true,
                    Token = token,
                    BenutzerDto = new BenutzerDto()
                    {
                        Name = benutzer.Name,
                        vorname=benutzer.Vorname,
                        Id = benutzer.Id,
                        Email = benutzer.Email,
                        HandyNummer = benutzer.HandyNummer
                    }
                });

            }
            else
            {
                return Unauthorized(new SignInResponseDto
                {
                    IsAuthErfolgreich = false,
                    ErrorMessage = "Ungültige Authentifizierung"
                });
            }


            return StatusCode(201);


        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationBenutzer benutzer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,benutzer.Email),
                new Claim(ClaimTypes.Email,benutzer.Email),
                new Claim("Id",benutzer.Id)
            };

            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(benutzer.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}
