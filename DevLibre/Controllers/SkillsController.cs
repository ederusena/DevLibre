using DevLibre.Entities;
using DevLibre.Models;
using DevLibre.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLibre.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly DevLivreDbContext _context;
        public SkillsController(DevLivreDbContext context)
        {
            _context = context;
        }

        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();

            return Ok(skills);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return NoContent();
        }
    }
}