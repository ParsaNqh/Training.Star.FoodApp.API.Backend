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
        public Restaurant RestaurantName { get; set; }
        public string RestaurantNameTitle { get; set; }
        public ApplicationUser RestaurantOwner { get; set; }
        public string RestaurantOwnerUsername { get; set; }
        public List<String> Foood { get; set; } = new List<string>();
        public double Price { get; set; }
    }
}
