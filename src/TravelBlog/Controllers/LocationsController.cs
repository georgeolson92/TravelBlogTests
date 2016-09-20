using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationRepository locationRepo;

        public LocationsController(ILocationRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.locationRepo = new EFLocationRepository();
            }
            else
            {
                this.locationRepo = thisRepo;
            }
        }


        public IActionResult Index()
        {
            return View(locationRepo.Locations.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisLocation = locationRepo.Locations
                .Include(locations => locations.Experiences)
                .FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            locationRepo.Save(location);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            locationRepo.Edit(location);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = locationRepo.Locations.FirstOrDefault(locations => locations.LocationId == id);
            locationRepo.Remove(thisLocation);
            return RedirectToAction("Index");
        }

    }
}
