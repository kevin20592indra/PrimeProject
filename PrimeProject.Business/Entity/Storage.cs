using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeProject.Business.Entity
{
    public class Stock
    {
        public Guid StockId { get; set; }
        public string BuyPrice { get; set; }
        public string SellPrice { get; set; }
        public string StockDate { get; set; }
        public string Parameters { get; set; }
        public string Supplier { get; set; }
        public string Purchaser { get; set; }
        public int StockCount { get; set; }
        public virtual Item Item { get; set; }
    }
}
