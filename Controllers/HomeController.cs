using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WendingMachineForKSKExpert.Models;
using WendingMachineForKSKExpert;

namespace WendingMachineForKSKExpert.Controllers
{
    public class HomeController : Controller
    {
        public int sum;
        DataBaseContext db = new DataBaseContext();
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.QueryString["admin"] == "yes")
                return Redirect(Url.Action("Index", "Admin"));
            else
            {
                IEnumerable<DrinksModel> drinks = db.Drinks;
                ViewBag.Drinks = drinks;
                ViewBag.RestOfMoney = 0;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(string SumMoney, string clickonbutton, string clickbuttoncoin, string buttonrestofmoney)
        {
            ViewBag.Title = buttonrestofmoney;
            ViewBag.RestOfMoney = 0;
            if (!string.IsNullOrEmpty(SumMoney)) sum = int.Parse(SumMoney);
            if (!string.IsNullOrEmpty(clickbuttoncoin)) sum += int.Parse(clickbuttoncoin);
            if (!string.IsNullOrEmpty(clickonbutton))
            {
                DrinksModel Drink = db.Drinks.FirstOrDefault(d => d.drinkName == clickonbutton);
                if (sum >= Drink.price) {
                    Drink.amount--;
                    db.SaveDrink(Drink);
                    clickonbutton = "";
                    clickbuttoncoin = "";
                    ViewBag.RestOfMoney = sum - (int)Drink.price;
                    sum = ViewBag.RestOfMoney;
                }
            }
            if (!string.IsNullOrEmpty (buttonrestofmoney)) {
                int change = sum;
                string res = "Вот вам ";
                while (change != 0)
                {
                    if (change / 10 > 0)
                    {
                        res = res + (change / 10).ToString() + " монет по 10; ";
                        change= change % 10;
                    }
                    if (change / 5 > 0)
                    {
                        res = res + (change / 5).ToString() + " монет по 5; ";
                        change = change % 5;
                    }
                    if (change / 2 > 0)
                    {
                        res = res + (change / 2).ToString() + " монет по 2; ";
                        change = change % 2;
                    }
                    if (change / 1 > 0)
                    {
                        res = res + (change / 1).ToString() + " монет по 1; ";
                        change = change % 1;
                    }
                }
                ViewBag.Change = res;
                sum = 0;
            }
            IEnumerable<DrinksModel> drinks = db.Drinks;
            ViewBag.Drinks = drinks;
            ViewBag.SumMoney=sum;
            return View();
        }
        public string GetImage(int drinkId)
        {
            DrinksModel drink = db.Drinks.FirstOrDefault(p => p.drinkId == drinkId);
            if (drink != null && drink.imageData!=null)
            {
                return drink.imageData.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}