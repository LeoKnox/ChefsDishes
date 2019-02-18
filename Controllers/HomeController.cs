using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefNDishContext dbContext;

        public HomeController(ChefNDishContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Chef>AllChefs = dbContext.MyChefs.Include(d => d.CreatedDishes).ToList();
            DateTime myDate = DateTime.Now;
            var year = myDate.Subtract(AllChefs[0].Dob);
            int age = myDate.Year;
            ViewBag.age = age;
            return View("Index", AllChefs);
        }

        [Route("addChef")]
        [HttpGet]
        public IActionResult addChef()
        {
            return View("newChef");
        }

        [Route("createChef")]
        [HttpPost]
        public IActionResult createChef(Chef newChef)
        {
            if (ModelState.IsValid) {
                newChef.CreatedAt = DateTime.Now;
                newChef.UpdatedAt = DateTime.Now;
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return View("Index");
            }
            else
            {
                return View("newChef");
            }
        }

        [Route("dishes")]
        [HttpGet]
        public IActionResult dishes()
        {
            List<Dish>AllDishes = dbContext.MyDishes.Include(c => c.Creator).ToList();
            return View("dishIndex", AllDishes);
        }

        [Route("addDish")]
        [HttpGet]
        public IActionResult addDish()
        {
            List<Chef> AllChefs = dbContext.MyChefs.Include(Dish => Dish.CreatedDishes).ToList();
            ViewBag.cooks = AllChefs;
            return View("newDish");
        }

        [Route("makeDish")]
        [HttpPost]
        public IActionResult makeDish(Dish createdDish)
        {
            if (ModelState.IsValid) {
                createdDish.CreatedAt = DateTime.Now;
                createdDish.UpdatedAt = DateTime.Now;
                dbContext.Add(createdDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<Chef> AllChefs = dbContext.MyChefs.Include(Dish => Dish.CreatedDishes).ToList();
                ViewBag.cooks = AllChefs;
                return View ("newDish");
            }
        }
    }
}
