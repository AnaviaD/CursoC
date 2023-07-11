using Microsoft.EntityFrameworkCore;
using StudentApi.Models.Domain;

namespace StudentApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
