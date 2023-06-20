using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WendingMachineForKSKExpert.Models
{
    public class DrinksModel
    {
        [Key]
        public int drinkId { get; set; }
        public string drinkName { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public int locked { get; set; }
        public string imageData { get; set; }
    }
}