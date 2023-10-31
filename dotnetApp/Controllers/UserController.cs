using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Email = "admin@example.com" }
        };

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
    
            newUser.Id = _users.Max(u => u.Id) + 1;
            
            
            _users.Add(newUser);
            
            
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }


        [HttpPut("{id}")]

        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = _users.Find(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update user properties
            existingUser.Username = updatedUser.Username;
            existingUser.Email = updatedUser.Email;

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _users.Find(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Remove the user from the list
            _users.Remove(existingUser);

            return NoContent();
        }

    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
