using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using NZWalks.API.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
       // private readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {

            var userIdentity = new IdentityUser()
            {

                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityresult = await userManager.CreateAsync(userIdentity, registerRequestDto.Password);

            if (identityresult.Succeeded)
            {
                {
                    if (registerRequestDto.Roles.Any() && registerRequestDto.Roles != null)
                    {
                        identityresult = await userManager.AddToRolesAsync(userIdentity, registerRequestDto.Roles);

                        if (identityresult.Succeeded)
                        { 
                                return Ok("User was Registed Successfully! Login Please");
                        }
                    }
                }              
            }
            return BadRequest("Something went Wrong");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {

            //var user = await userManager.FindByEmailAsync(loginRequest.Username);

            //if(user != null)
            //{
            //    var PasswordCheck = await userManager.CheckPasswordAsync(user, loginRequest.Password);
            //    if(PasswordCheck)
            //    {
            //        var roles= await userManager.GetRolesAsync(user);
            //        if (roles != null) 
            //        {
            //            var JwtToken1 = tokenRepository.CreateJwtToken(user, roles.ToList());
            //            var response = new LoginResponseDto
            //            {
            //                JwtToken = JwtToken1
            //            };
            //            return Ok(response);
            //        }

            //    }
            //}

            //return BadRequest("UserName and Password incorrect");
            
                if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.Password))
                {
                    return BadRequest("Username and Password must be provided.");
                }

                var user = await userManager.FindByEmailAsync(loginRequest.Username);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var isPasswordValid = await userManager.CheckPasswordAsync(user, loginRequest.Password);
                if (!isPasswordValid)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var roles = await userManager.GetRolesAsync(user);
                var jwtToken = tokenRepository.CreateJwtToken(user, roles.ToList());

                var response = new LoginResponseDto
                {
                    JwtToken = jwtToken
                };

                return Ok(response);
            }



        
    }
}
