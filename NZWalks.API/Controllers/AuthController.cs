using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Diagnostics.Eventing.Reader;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILoginTokenRepository loginTokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ILoginTokenRepository loginTokenRepository)
        {
            this.userManager = userManager;
            this.loginTokenRepository = loginTokenRepository;
        }

        // create a register method > POST /api/Auth/Register 
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            /*
             1. Create a register request DTO with username and password and pass it as methods' parameter, because the method receives some information from the user 
             2. Register a user, using User Manager class provided from Identity > injected in the constructor
             3. use the identity result to check if it succeded and add roles to the user > addToRolesAsync method from UserManager class
             */

            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // add roles to this user
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {

                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was register! Please login");
                    }
                }

            }
                return BadRequest("Something went wrong");
        }


        // LOGIN functionality 
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            // use the UserManager class 
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username); //hover over it -> this is a Identity user and can be null

            if (user != null)
            {
                // check if the password is correct or not
               var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password); // this returns true or false 

                if (checkPasswordResult)
                {
                    // get the roles for this user
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {

                        // create user token along with users' roles and return an ok response
                        // good practice is to create the tokens inside repositories 

                        var jwtToken = loginTokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }

                }
            }

            return BadRequest("Userame or Password is incorrect.");
        }
    }
}
 