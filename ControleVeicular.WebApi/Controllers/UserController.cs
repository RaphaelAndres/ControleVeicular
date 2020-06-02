using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ControleVeicular.Domain.Model.Identity;
using ControleVeicular.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ControleVeicular.WebApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        public IConfiguration Config { get; }
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        public IMapper Mapper { get; }

        public UserController (IConfiguration config, UserManager<User> userManager, 
                               SignInManager<User> signInManager, IMapper mapper) {
            this.Mapper = mapper;
            this.SignInManager = signInManager;
            this.UserManager = userManager;
            this.Config = config;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(new UserDto());
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                var user = Mapper.Map<User>(userDto);
                var result = await UserManager.CreateAsync(user, userDto.Password);
                var userReturn = Mapper.Map<UserDto>(result);
                if (result.Succeeded) 
                {
                    return Created("GetUser", userReturn);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(userLoginDto.Email);
                var result = await SignInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await UserManager.Users
                        .FirstOrDefaultAsync(us => us.NormalizedEmail == userLoginDto.Email.ToUpper());
                    var userReturn = Mapper.Map<UserLoginDto>(appUser);
                    return Ok(new {
                        token = GenerateJwToken(appUser).Result,
                        user = userReturn
                    });
                }

                return Unauthorized();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro genérico");
            }
        }

        private async Task<string> GenerateJwToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await UserManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(Config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        
        }
    }
}