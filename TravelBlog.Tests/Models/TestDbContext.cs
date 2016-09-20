using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Models;

namespace TravelBlog.Tests.Models
{
    public class TestDbContext : TravelBlogDbContext
    {
        public override DbSet<Location> Locations { get; set; }

        public override DbSet<Experience> Experiences { get; set; }

        public override DbSet<People> Peoples { get; set; }

        public override DbSet<PeopleExperience> PeopleExperiences { get; set; }

        public override DbSet<PeopleLocation> PeopleLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlogTest;integrated security = True");
        }
    }
}
