using Lite_Berry_Pi.Models.Api;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
  public interface IUserService
  {
    public Task<ApplicationUserDto> Register(RegisterUser data, ModelStateDictionary modelState);

    public Task<ApplicationUserDto> Authenticate(string username, string password);

    public Task<ApplicationUserDto> GetUser(ClaimsPrincipal user);
  }
}
