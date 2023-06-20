using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WendingMachineForKSKExpert.Models
{
    public class DataBaseInitializer : DropCreateDatabaseAlways<DataBaseContext>
    {
        protected override void Seed(DataBaseContext db)
        {
            db.Drinks.Add(new DrinksModel { drinkId = 1, drinkName = "Кола", price = 1, amount=2, locked=0});
            db.Drinks.Add(new DrinksModel { drinkId = 2, drinkName = "Вода", price = 1, amount = 2 , locked = 0 });
            db.Drinks.Add(new DrinksModel { drinkId = 3, drinkName = "Квас", price = 1, amount = 2, locked = 1 });

            base.Seed(db);
        }
    }
}