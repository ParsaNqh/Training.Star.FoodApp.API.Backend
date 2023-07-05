using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star.FoodApp.Core.Entities
{
    public class ApplicationUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
    }
}
