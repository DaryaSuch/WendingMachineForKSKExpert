using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WendingMachineForKSKExpert.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<DrinksModel> Drinks { get; set; }
        public void SaveDrink(DrinksModel drink)
        {
            DataBaseContext db = new DataBaseContext();
            if (drink.drinkId == 0)
            {
                db.Drinks.Add(drink);
            }
            else
            {
                DrinksModel dbEntry = db.Drinks.Find(drink.drinkId);
                if (dbEntry != null)
                {
                    dbEntry.drinkName = drink.drinkName;
                    dbEntry.price = drink.price;
                    dbEntry.amount = drink.amount;
                }
            }
            db.SaveChanges();
        }
        public DrinksModel DeleteDrink(int drinkId)
        {
            DataBaseContext db = new DataBaseContext();
            DrinksModel dbEntry = db.Drinks.Find(drinkId);
            if (dbEntry != null)
            {
                db.Drinks.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}