using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Domain.IService
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryVM>> GetInventoryItems();
        Task<IEnumerable<InventoryVM>> GetInventoryByType(string type);
        Task<InventoryVM> GetInventoryById(int id);
        Task<Inventory> CreateInventory(InventoryVM inventoryVM);
        Task<IEnumerable<Inventory>> CreateBulkInventory(List<InventoryVM> inventoryItems);
        Task<Inventory> UpdateInventory(InventoryVM inventoryVM);
        Task<bool> DeleteInventory(int id);
    }
}
