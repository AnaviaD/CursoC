using Microsoft.EntityFrameworkCore;
using testAppN1.Models.Domain;

namespace testAppN1.Data
{
    public class NZWalksDbContext:DbContext 
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
        }

        public DbSet<Difficulty>    difficulties { get; set; }
        public DbSet<Region>        regions { get; set; }  
        public DbSet<Walk>          walks { get; set; }
    }
}
