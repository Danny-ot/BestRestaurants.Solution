using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{

    public class CuisinesController : Controller
    {
        private readonly BestRestaurantsContext _db;
        public CuisinesController(BestRestaurantsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisines.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Cuisine cuisine = _db.Cuisines.FirstOrDefault(cuis => cuis.CuisineId == id);
            return View(cuisine);
        }

        public ActionResult Edit(int id)
        {
            Cuisine cuisine = _db.Cuisines.FirstOrDefault(cuis => cuis.CuisineId == id);
            return View(cuisine);
        }

        [HttpPost]
        public ActionResult Edit(Cuisine cuisine)
        {
            _db.Entry(cuisine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Cuisine cuisine = _db.Cuisines.FirstOrDefault(cuis => cuis.CuisineId == id);
            return View(cuisine);
        }

        [HttpPost , ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuisine cuisine = _db.Cuisines.FirstOrDefault(cuis => cuis.CuisineId == id);
            _db.Cuisines.Remove(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}