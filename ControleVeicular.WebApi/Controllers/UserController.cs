using System;
using System.Threading.Tasks;
using AutoMapper;
using ControleVeicular.Domain.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        // [HttpGet("GetUser")]
        // public async Task<IActionResult> GetUser()
        // {
        //     return Ok(new User());
        // }

        // [HttpPost("Register")]
        // public async Task<IActionResult> Register(User user)
        // {
        //     try
        //     {
        //         var result = await UserManager.CreateAsync(user, user.P)
        //     }
        //     catch (Exception)
        //     {

        //     }
        // }
    }
}