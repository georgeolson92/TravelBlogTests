using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Models
{
    public class EFLocationRepository : ILocationRepository
    {
        TravelBlogDbContext db = new TravelBlogDbContext();

        public IQueryable<Location> Locations
        { get { return db.Locations; } }

        public Location Save(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location;
        }

        public Location Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return location;
        }

        public void Remove(Location location)
        {
            db.Locations.Remove(location);
            db.SaveChanges();
        }
    }

}
