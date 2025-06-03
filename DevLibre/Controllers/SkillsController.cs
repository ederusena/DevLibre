using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevLibre.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        // GET: api/skills
        [HttpGet]
        public IActionResult GetSkills()
        {
            // Logic to get skills
            return Ok(new List<string> { "Skill1", "Skill2" });
        }

        // POST: api/skills
        [HttpPost]
        public IActionResult CreateSkill([FromBody] string skill)
        {
            // Logic to create a skill
            return CreatedAtAction(nameof(GetSkills), new { id = 1 }, skill);
        }

        // PUT: api/skills/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSkill(int id, [FromBody] string skill)
        {
            // Logic to update a skill
            return NoContent();
        }

        // DELETE: api/skills/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            // Logic to delete a skill
            return NoContent();
        }
    }
}