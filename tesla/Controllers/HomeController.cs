using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tesla.Models;
using tesla.ViewModels;

namespace tesla.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            CarViewModel LBDV = new CarViewModel
            {
                Car = db.Car.OrderByDescending(c => c.id).Take(3)
            };
            return View(LBDV);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}