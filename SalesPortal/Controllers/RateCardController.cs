using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesPortal.Data;
using SalesPortal.Models;
namespace SalesPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateCardController : Controller
    {
        private readonly ApplicationDataDbContext _applicationDataDbContext;

        public RateCardController(ApplicationDataDbContext applicationDataDbContext)
        {
            _applicationDataDbContext = applicationDataDbContext;
        }

        //the Get Method for skills Model
        [HttpGet]
        public async Task<IActionResult> GetAllRateCard()
        {
            var rateCard = await _applicationDataDbContext.RateCard.ToListAsync();
            return Ok(rateCard);
        }
        [HttpPost]
        public async Task<IActionResult> AddRateCard([FromBody] RateCardModel rateCardRequest)
        {
            rateCardRequest.RateCardID = Guid.NewGuid();
            await _applicationDataDbContext.RateCard.AddAsync(rateCardRequest);
            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(rateCardRequest);
        }

        [HttpGet]
        [Route("{RateCardID:Guid}")]
        public async Task<IActionResult> GetRateCard([FromRoute] Guid id)
        {
            var rate = await _applicationDataDbContext.RateCard.FirstOrDefaultAsync(x => x.RateCardID == id);
            if (rate == null)
            {
                return NotFound();
            }



            return Ok(rate);
        }



        [HttpPut]
        [Route("{RateCardID:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, RateCardModel updateRateRequest)
        {
            var rate = await _applicationDataDbContext.RateCard.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }
            /* public Guid RateCardID { get; set; }
        public virtual Guid SkillID { get; set; }
        [ForeignKey("SkillID")]
        public virtual SkillsModel Skills { get; set; }
        public int MinYrExperience { get; set; }
        public int MaxYrExperience { get; set;}
        public double RatePerHrUSD { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public Guid LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
*/

            rate.MinYrExperience = updateRateRequest.MinYrExperience;
            rate.MaxYrExperience = updateRateRequest.MaxYrExperience;
            rate.RatePerHrUSD = updateRateRequest.RatePerHrUSD;
           rate.LastUpdatedBy= updateRateRequest.LastUpdatedBy;
            rate.CreatedOn = updateRateRequest.CreatedOn;
            rate.LastUpdatedOn = updateRateRequest.LastUpdatedOn;




            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(rate);
        }



        [HttpDelete]
        [Route("{RateCardID:Guid}")]
        public async Task<IActionResult> DeleteRateCard([FromRoute] Guid id)
        {
            var rate = await _applicationDataDbContext.RateCard.FindAsync(id);
            if (rate == null)
            {
                return NotFound();
            }



            _applicationDataDbContext.RateCard.Remove(rate);
            await _applicationDataDbContext.SaveChangesAsync();
            return Ok(rate);
        }
    }
}
    