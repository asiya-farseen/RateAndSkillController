using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Data;
using SalesPortal.Models;

namespace SalesPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : Controller
    {
        private readonly ApplicationDataDbContext _applicationDataDbContext;

        public SkillsController(ApplicationDataDbContext applicationDataDbContext)
        {
            _applicationDataDbContext = applicationDataDbContext;
        }

        //the Get Method for skills Model
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _applicationDataDbContext.Skills.ToListAsync();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkills([FromBody] SkillsModel skillsRequest)
        {
            skillsRequest.SkillID = Guid.NewGuid();
            await _applicationDataDbContext.Skills.AddAsync(skillsRequest);
            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(skillsRequest);
        }
        [HttpGet]
        [Route("{SkillID:Guid}")]
        public async Task<IActionResult> GetSkills([FromRoute] Guid id)
        {
            var skill = await _applicationDataDbContext.Skills.FirstOrDefaultAsync(x => x.SkillID == id);
            if (skill == null)
            {
                return NotFound();
            }



            return Ok(skill);
        }



        [HttpPut]
        [Route("{SkillID:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, SkillsModel updateSkillRequest)
        {
            var skill = await _applicationDataDbContext.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            skill.Skill = updateSkillRequest.Skill;
          
        




            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(skill);
        }



        [HttpDelete]
        [Route("{SkillID:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var skill = await _applicationDataDbContext.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }



            _applicationDataDbContext.Skills.Remove(skill);
            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(skill);
        }
    }
}