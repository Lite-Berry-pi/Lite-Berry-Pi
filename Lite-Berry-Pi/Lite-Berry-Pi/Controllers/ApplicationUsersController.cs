using Lite_Berry_Pi.Models.Api;
using Lite_Berry_Pi.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private IUserService userService;

        public ApplicationUsersController(IUserService service)
        {
            userService = service;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<ApplicationUserDto>> Register(RegisterUser data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<ApplicationUserDto>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user != null)
            {
                return user;
            }
            return Unauthorized();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("me")]
        public async Task<ActionResult<ApplicationUserDto>> Me()
        {
            return await userService.GetUser(this.User);
        }
    }
}
