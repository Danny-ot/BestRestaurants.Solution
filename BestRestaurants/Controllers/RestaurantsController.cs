using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BestRestaurants.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly BestRestaurantsContext _db;
        public RestaurantsController(BestRestaurantsContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Restaurant> model = _db.Restaurants.Include(rest => rest.Cuisine).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CuisineId = new SelectList(_db.Cuisines , "CuisineId" , "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Restaurant restaurant = _db.Restaurants.FirstOrDefault(rest => rest.RestaurantId == id);
            return View(restaurant);
        }

        public ActionResult Edit(int id)
        {
             var restaurant = _db.Restaurants.FirstOrDefault(rest => rest.RestaurantId == id);
            ViewBag.CuisineId = new SelectList(_db.Cuisines , "CuisineId" , "Name");
            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            _db.Entry(restaurant).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var restaurant = _db.Restaurants.FirstOrDefault(rest => rest.RestaurantId == id);
            return View(restaurant);
        }

        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var restaurant = _db.Restaurants.FirstOrDefault(rest => rest.RestaurantId == id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}