using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository;

namespace RepositoryPattern_Postgresql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRepository<User> _user;

        public TestController( IRepository<User> user )
        {
            _user = user;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _user.GetAll());
        }

        [HttpGet("GetUser{id}")]
        public async Task<ActionResult<User>> GetUser( int id )
        {
            var user = await _user.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody] User user )
        {
            await _user.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpDelete("RemoveUser{id}")]
        public async Task<IActionResult> RemoveUser( int id )
        {
            var user = await _user.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _user.Remove(user);
            return NoContent();
        }
    }
}
