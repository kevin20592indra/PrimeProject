using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeProject.Business.Entity
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public string Parameters { get; set; }
    }
}
