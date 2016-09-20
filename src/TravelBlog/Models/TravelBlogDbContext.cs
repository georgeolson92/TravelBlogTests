using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class TravelBlogDbContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Experience> Experiences { get; set; }

        public virtual DbSet<People> Peoples { get; set; }

        public virtual DbSet<PeopleExperience> PeopleExperiences { get; set; }

        public virtual DbSet<PeopleLocation> PeopleLocations { get; set; }

        
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
