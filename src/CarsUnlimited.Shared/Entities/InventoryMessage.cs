using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsUnlimited.CartShared.Entities
{
    public class InventoryMessage
    {
        public string Id { get; set; }
        public int StockAdjustment { get; set; }
    }
}
