using Microsoft.EntityFrameworkCore;
using NZWalksAPI2.Models.Domain;

namespace NZWalksAPI2.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walks> Walks { get; set; }

    }
}
