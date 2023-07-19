using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star.FoodApp.Core.Entities
{
    public class BassEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public BassEntity()
        {
            CreationTime = DateTime.Now;
        }
    }
}