using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.Entity.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string DrinkName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
