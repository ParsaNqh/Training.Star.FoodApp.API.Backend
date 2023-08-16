using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Star.FoodApp.Core.Entities
{
    public class RestaurantFood:BassEntity
    {
        public Restaurant RestaurantTitle { get; set; }
        public string RestaurantTitleId { get; set; }
        public String Title { get; set; } 
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
