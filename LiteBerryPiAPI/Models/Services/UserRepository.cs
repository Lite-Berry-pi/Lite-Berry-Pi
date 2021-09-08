using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models.Api;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces.Services
{
  public class UserRepository : IUser
  {

    private readonly LiteBerryDbContext _context;

    public UserRepository(LiteBerryDbContext context)
    {
      _context = context;
    }

    /// create user      
    public async Task<User> CreateUser(User inboundData)
    {
      User user = new User()
      {
        Id = inboundData.Id,
        Name = inboundData.Name
      };

      _context.Entry(user).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return user;
    }

    /// delete user
    public async Task Delete(int id)
    {
      User user = await _context.User.FindAsync(id);
      _context.Entry(user).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    /// get all users
    public async Task<List<UserDto>> GetListOfUsers()
    {
      return await _context.User
          .Select(user => new UserDto
          {
            Id = user.Id,
            Name = user.Name,
            UserDesigns = user.UserDesigns
                  .Select(design => new DesignDto
                  {
                    Id = design.Designs.Id,
                    Title = design.Designs.Title,
                    DesignCoords = design.Designs.DesignCoords

                  }).ToList(),
            ActivityLogs = user.ActivityLogs
                  .Select(logs => new ActivityLog
                  {
                    Id = logs.Id,
                    LoginTime = logs.LoginTime,
                    SendTime = logs.SendTime
                  }).ToList()
          }).ToListAsync();
    }

    // get user by ID
    public async Task<UserDto> GetSingleUser(int id)
    {
      return await _context.User
          .Where(x => x.Id == id)
          .Select(user => new UserDto
          {
            Id = user.Id,
            Name = user.Name,
            UserDesigns = user.UserDesigns
                  .Select(design => new DesignDto
                  {
                    Id = design.Designs.Id,
                    Title = design.Designs.Title,
                    DesignCoords = design.Designs.DesignCoords

                  }).ToList(),
            ActivityLogs = user.ActivityLogs
                  .Select(logs => new ActivityLog
                  {
                    Id = logs.Id,
                    LoginTime = logs.LoginTime,
                    SendTime = logs.SendTime
                  }).ToList()
            // add designs and logs
          }).FirstOrDefaultAsync();
    }

    /// update user
    public async Task<User> UpdateUser(int id, User user)
    {

      _context.Entry(user).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return user;
    }

    /// add a design to a user
    public async Task AddDesignToUser(int userId, int designId)
    {
      UserDesign userDesign = new UserDesign()
      {
        UserId = userId,
        DesignId = designId
      };

      _context.Entry(userDesign).State = EntityState.Added;
      await _context.SaveChangesAsync();
    }

    /// remove a design from a user
    public async Task RemoveDesignFromUser(int userId, int designId)
    {
      var userDesign = await _context.UserDesign.FirstOrDefaultAsync(
          x => x.DesignId == designId && x.UserId == userId);
      _context.Entry(userDesign).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

  }
}
