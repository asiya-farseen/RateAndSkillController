using System;
using System.ComponentModel.DataAnnotations;

namespace SalesPortal.Models
{
    public class SkillsModel
    {

        [Key]
        public Guid SkillID { get; set; }
        public string  Skill { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public Guid LastUpdatedBy { get;}
        public DateTime LastUpdatedOn { get; set;}
       
    }
}
