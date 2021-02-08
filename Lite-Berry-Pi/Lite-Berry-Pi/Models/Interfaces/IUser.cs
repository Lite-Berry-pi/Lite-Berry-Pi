using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);

        Task <List<User>> GetListOfUsers();

        Task<User> GetSingleUser(int id);

        Task<User> UpdateUser(int id, User user);

        Task Delete(int id);

        Task AddDesignToUser(int userId, int designId);

        Task RemoveDesignFromUser(int userId, int designId);
    }
}
