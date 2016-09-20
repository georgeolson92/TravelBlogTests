using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Models
{
    public class EFPeopleRepository : IPeopleRepository
    {
        TravelBlogDbContext db;
        public EFPeopleRepository(TravelBlogDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new TravelBlogDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<People> Peoples
        {  get { return db.Peoples; } }

        public People Save(People people)
        {
            db.Peoples.Add(people);
            db.SaveChanges();
            return people;
        }

        public People Edit(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return people;
        }

        public void Remove(People people)
        {
            db.Peoples.Remove(people);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            var l = Peoples;
            db.Peoples.RemoveRange(l);
            db.SaveChanges();
        }

    }

}
