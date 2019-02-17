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
            List<Chef>AllChefs = dbContext.MyChefs.ToList();
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
            newChef.CreatedAt = DateTime.Now;
            newChef.UpdatedAt = DateTime.Now;
            dbContext.Add(newChef);
            dbContext.SaveChanges();
            return View("Index");
        }

        [Route("dishes")]
        [HttpGet]
        public IActionResult dishes()
        {
            return View("dishIndex");
        }

        [Route("addDish")]
        [HttpGet]
        public IActionResult addDish()
        {
            List<Chef>AllChefs = dbContext.MyChefs.ToList();
            ViewBag.cooks = AllChefs;
            return View("newDish", AllChefs);
        }
    }
}
