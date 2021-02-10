using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Api;
using Lite_Berry_Pi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IUser _user;

    public UsersController(IUser user)
    {
      _user = user;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUser()
    {
      return Ok(await _user.GetListOfUsers());
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
      UserDto user = await _user.GetSingleUser(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, User user)
    {
      if (id != user.Id)
      {
        return BadRequest();
      }
      var updatedUser = await _user.UpdateUser(id, user);
      return Ok(updatedUser);
    }

    // POST: api/Users
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
      await _user.CreateUser(user);
      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
      await _user.Delete(id);
      return NoContent();
    }
  }
}
