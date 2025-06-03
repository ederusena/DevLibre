using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevLibre.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Logic to get users
            return Ok(new List<string> { "User1", "User2" });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            // Logic to get user by id
            return Ok($"User{id}");
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] string user)
        {
            // Logic to create a user
            return CreatedAtAction(nameof(GetUserById), new { id = 1 }, user);
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult UploadProfilePicture(int id, IFormFile picture)
        {
            var description = $"Profile: {id}, File: {picture.FileName}, Size: {picture.Length} bytes";

            // Logic to upload profile picture
            // For example, save the file to a server or cloud storage
            // Here we just return a description of the uploaded file
            return Ok(description);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] string user)
        {
            // Logic to update a user
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Logic to delete a user
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchUsers([FromQuery] string query)
        {
            // Logic to search users
            return Ok(new List<string> { "User1", "User2" });
        }

        
    }
}