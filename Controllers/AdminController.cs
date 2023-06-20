using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WendingMachineForKSKExpert.Models;

namespace WendingMachineForKSKExpert.Controllers
{
    public class AdminController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        HomeController homeController = new HomeController();
        public ActionResult Index()
        {
            IEnumerable<DrinksModel> drinks = db.Drinks;
            ViewBag.Drinks = drinks;
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? delete, DrinksModel drink, string coin)
        {
            HomeController homeController = new HomeController();
            IEnumerable<DrinksModel> drinks = db.Drinks;
            ViewBag.Drinks = drinks;
            DrinksModel newDrink = new DrinksModel();
            if (delete != null)
            {
                DrinksModel deletedProduct = db.DeleteDrink(int.Parse(delete.ToString()));
            }
            if (!string.IsNullOrEmpty(drink.drinkName) || drink.drinkId!=0)
            {
                db.SaveDrink(drink);

            }
            return View();
        }
    }
}