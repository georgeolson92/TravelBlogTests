using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class TravelBlogDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Experience> Experiences { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }
    }
}
