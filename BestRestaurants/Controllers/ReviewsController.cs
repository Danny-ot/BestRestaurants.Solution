using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly BestRestaurantsContext _db;
        public ReviewsController(BestRestaurantsContext db)
        {
            _db = db;
        }
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(_db.Restaurants , "RestaurantId" , "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToAction("Index" , "Restaurants");
        }
    }
}