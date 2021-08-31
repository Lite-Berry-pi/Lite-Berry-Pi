using Lite_Berry_Pi.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
  public interface IUser
  {
    Task<User> CreateUser(User user);

    Task<List<UserDto>> GetListOfUsers();

    Task<UserDto> GetSingleUser(int id);

    Task<User> UpdateUser(int id, User user);

    Task Delete(int id);

    Task AddDesignToUser(int userId, int designId);

    Task RemoveDesignFromUser(int userId, int designId);
  }
}
