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
            db.Drinks.Add(new DrinksModel { drinkId = 1, drinkName = "Л. Толстой", price = 1, amount=2, locked=0});
            db.Drinks.Add(new DrinksModel { drinkId = 2, drinkName = "И. Тургенев", price = 1, amount = 2 , locked = 0 });
            db.Drinks.Add(new DrinksModel { drinkId = 3, drinkName = "А. Чехов", price = 1, amount = 2, locked = 1 });

            base.Seed(db);
        }
    }
}