using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PeoplesController : Controller
    {
        private TravelBlogDbContext db = new TravelBlogDbContext();
        public IActionResult Index()
        {
            return View(db.Peoples.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            
            var thisPeople = db.Peoples
                .Include(peoples => peoples.PeopleExperiences)
                .ThenInclude(peoples => peoples.Experience)
                .FirstOrDefault(peoples => peoples.PersonId == id);
            var experiences = thisPeople.PeopleExperiences.Select(pe => pe.Experience).ToList();
            //var model = new Dictionary<string, object>;
            //model.Add("people", thisPeople);
            //model.Add("experiences", experiences);
            foreach(PeopleExperience pE in thisPeople.PeopleExperiences)
            {
                Console.WriteLine(pE.Experience.Title);
            }
            return View(thisPeople);
        }

        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "CityName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            db.Peoples.Add(people);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PersonId == id);
            return View(thisPeople);
        }

        [HttpPost]
        public IActionResult Edit(People people)
        {
            db.Entry(people).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PersonId == id);
            return View(thisPeople);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPeople = db.Peoples.FirstOrDefault(peoples => peoples.PersonId == id);
            db.Peoples.Remove(thisPeople);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
