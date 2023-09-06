using Star.FoodApp.Core.Enum;
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
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string City { get; set; }
        public ApplicationUserType Type { get; set; }
        public bool Verified { get; set; }
        public string VerificationCode { get; set; }
    }
}
