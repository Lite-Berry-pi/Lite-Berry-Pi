﻿using Lite_Berry_Pi.Models.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<ApplicationUser> userManager;
    private JwtTokenService tokenService;

    public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
    {
      userManager = manager;
      tokenService = jwtTokenService;
    }

    public async Task<ApplicationUserDto> Register(RegisterUser data, ModelStateDictionary modelState
        )
    {
      var user = new ApplicationUser
      {
        UserName = data.Username,



      };

      var result = await userManager.CreateAsync(user, data.Password);

      if (result.Succeeded)
      {
        return new ApplicationUserDto
        {
          Id = user.Id,
          Username = user.UserName
        };
      }
      foreach (var error in result.Errors)
      {
        var errorKey =
            error.Code.Contains("Password") ? nameof(data.Password) :
            error.Code.Contains("UserName") ? nameof(data.Username) :
            "";

        modelState.AddModelError(errorKey, error.Description);
      }
      return null;
    }
    public async Task<ApplicationUserDto> Authenticate(string username, string password)
    {
      var user = await userManager.FindByNameAsync(username);
      if (await userManager.CheckPasswordAsync(user, password))
      {
        return new ApplicationUserDto
        {
          Id = user.Id,
          Username = user.UserName,
          Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
        };

      }
      return null;
    }

    public async Task<ApplicationUserDto> GetUser(ClaimsPrincipal principal)
    {
      var user = await userManager.GetUserAsync(principal);
      return new ApplicationUserDto
      {
        Id = user.Id,
        Username = user.UserName,
        Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
      };
    }


  }
}
