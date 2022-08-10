
using System;
using System.Collections.Generic;

namespace CarsUnlimited.InventoryShared.Entities
{
    public class InventoryItem 
    {
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public List<InventoryImage> Images { get; set; }   
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
