using CarsUnlimited.Shared.Attributes;
using CarsUnlimited.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarsUnlimited.InventoryAPI.Entities
{
    [BsonCollection("inventory")]
    public class InventoryItem : Document
    {
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public List<InventoryImage> Images { get; set; }
        public DateTime CreatedDate { get; set; }        
    }
}
