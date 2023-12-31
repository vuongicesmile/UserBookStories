﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.DataAccess.DTOs;
using UsedBookStore.DataAccess.Repositories;

namespace UsedBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) 
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            // now that we are passing the infomation as a input parameter
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName,
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                // Add roles to this User
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequestDto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User was registered ! Please login");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }

        //POST : /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            //checking email
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if(user != null)
            {
             var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            
            if(checkPasswordResult)
                {
                    // the controller should be lean and the functionally to create token
                    //get roles for this user
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        // Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginRepositoryDto
                        {
                            JwtToken = jwtToken,

                        };
                        return Ok(jwtToken);
                    }
                }
            }
            return BadRequest("Username or password incrrect");
        }
        
    }
}
