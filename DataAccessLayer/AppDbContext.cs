using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<ImageModel> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ImageProcessingDb");
        }
    }
}
