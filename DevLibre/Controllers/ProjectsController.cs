using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevLibre.Models;
using DevLibre.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevLibre.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly FreelanceTotalCostConfig _config;
        private readonly IConfigService _configService;
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options, IConfigService configService)
        {
            _config = options.Value;
            _configService = configService; // Example usage of the config service
        }

        // GET: api/projects
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string> { "Project1", "Project2" });
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Logic to get project by id
            return Ok($"Project{id}");
        }

        // GET: api/projects?search={query}
        [HttpGet("search")]
        public IActionResult GetByCrm([FromQuery] string query = "")
        {
            
            return Ok(_configService.GetValue());
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectInputModel model)
        {
            if (model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum)
            {
                return BadRequest("Numero fora dos limites.");
            }

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // POST : api/projects/{id}/comments
        [HttpPost("{id}/comments")]
        public IActionResult CreateComment(int id, CreateProjectCommentInputModel comment)
        {
            return Ok();
        }

        // PUT : api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        // PUT: api/projects/{id}/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // PUT: api/projects/{id}/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        // DELETE: api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }





    }
}