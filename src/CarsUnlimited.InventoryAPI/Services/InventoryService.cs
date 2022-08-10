using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using CarsUnlimited.InventoryAPI.Repository;
using CarsUnlimited.InventoryAPI.Entities;

namespace CarsUnlimited.InventoryAPI.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMongoRepository<InventoryItem> _inventoryItemRepository;

        public InventoryService(IMongoRepository<InventoryItem> inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }

        public List<InventoryItem> Get() =>
            _inventoryItemRepository.AsQueryable().OrderBy(x => x.Manufacturer).ThenBy(x => x.Model).ToList();

        public InventoryItem Get(string id) =>
            _inventoryItemRepository.FindById(id);

        public InventoryItem GetByManufacturerAndModel(string manufacturer, string model) =>
            _inventoryItemRepository.FindOne(x => x.Manufacturer == manufacturer && x.Model == model);        

        public List<InventoryItem> GetByCategory(string category) =>
            _inventoryItemRepository.FilterBy(x => x.Category == category).OrderBy(x => x.Manufacturer).ThenBy(x => x.Model).ToList();

        public List<InventoryItem> GetLatestByCategory(string category) =>
            _inventoryItemRepository.FilterBy(x => x.Category == category).OrderByDescending(x => x.CreatedDate).Take(3).ToList();

        public void Update(InventoryItem itemIn) =>
            _inventoryItemRepository.ReplaceOne(itemIn);

    }
}