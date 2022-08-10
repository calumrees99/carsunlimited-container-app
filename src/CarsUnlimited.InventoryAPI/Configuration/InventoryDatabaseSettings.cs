namespace CarsUnlimited.InventoryAPI.Configuration
{
    public interface IInventoryDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class InventoryDatabaseSettings : IInventoryDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}