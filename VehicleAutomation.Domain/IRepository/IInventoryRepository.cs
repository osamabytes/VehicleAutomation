using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Domain.IRepository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryVM>> GetInventoryItems();
        Task<IEnumerable<InventoryVM>> GetInventoryByType(string type);
        Task<InventoryVM> GetInventoryById(int id);
        Task<Inventory> CreateInventory(InventoryVM inventoryVM);
        Task<IEnumerable<Inventory>> CreateBulkInventory(List<InventoryVM> inventoryItems);
        Task<Inventory> UpdateInventory(InventoryVM inventoryVM);
        Task<bool> DeleteInventory(int id);
        Task<bool> TestChangeInventory();
    }
}
