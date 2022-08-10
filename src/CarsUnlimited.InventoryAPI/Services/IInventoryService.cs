using CarsUnlimited.InventoryAPI.Entities;
using System.Collections.Generic;

namespace CarsUnlimited.InventoryAPI.Services
{
    public interface IInventoryService
    {
        List<InventoryItem> Get();        
        InventoryItem Get(string id);
        InventoryItem GetByManufacturerAndModel(string manufacturer, string model);
        List<InventoryItem> GetByCategory(string category);
        List<InventoryItem> GetLatestByCategory(string category);
        void Update(InventoryItem itemIn);
    }
}
