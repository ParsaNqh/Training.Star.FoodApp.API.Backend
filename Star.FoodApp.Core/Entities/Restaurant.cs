using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star.FoodApp.Core.Entities
{
    public class Restaurant : BassEntity
    {
        public string Title { get; set; }
        public ApplicationUser RestaurantOwner { get; set; }
        public string RestaurantOwnerUsername { get; set; }
        public bool IsApproved { get; set; }
        public ApplicationUser? Approver { get; set; }
        public string? ApproverUsername { get;set; }
        public DateTime ApprovedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
