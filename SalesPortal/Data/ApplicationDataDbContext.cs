using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SalesPortal.Models;
namespace SalesPortal.Data
{
    public class ApplicationDataDbContext : DbContext
    {
        public ApplicationDataDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SkillsModel> Skills { get; set; }
       public DbSet<RateCardModel> RateCard { get; set; }
    }
}