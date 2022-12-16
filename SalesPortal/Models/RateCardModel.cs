using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesPortal.Models
{
    public class RateCardModel
    {



        [Key]
        public Guid RateCardID { get; set; }
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

 
    }
}
