using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.IRepository;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Infrastructure.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Inventory>> CreateBulkInventory(List<InventoryVM> inventoryItems)
        {
            var inventoryItemList = await _inventoryRepository.CreateBulkInventory(inventoryItems);
            return inventoryItemList;
        }

        public async Task<Inventory> CreateInventory(InventoryVM inventoryVM)
        {
            var inventory = await _inventoryRepository.CreateInventory(inventoryVM);
            return inventory;
        }

        public async Task<bool> DeleteInventory(int id)
        {
            var result = await _inventoryRepository.DeleteInventory(id);
            return result;
        }

        public async Task<InventoryVM> GetInventoryById(int id)
        {
            var inventory = await _inventoryRepository.GetInventoryById(id);
            return inventory;
        }

        public async Task<IEnumerable<InventoryVM>> GetInventoryByType(string type)
        {
            var inventoryItems = await _inventoryRepository.GetInventoryByType(type);
            return inventoryItems;
        }

        public async Task<IEnumerable<InventoryVM>> GetInventoryItems()
        {
            var inventoryItems = await _inventoryRepository.GetInventoryItems();
            return inventoryItems;
        }

        public async Task<Inventory> UpdateInventory(InventoryVM inventoryVM)
        {
            var inventory = await _inventoryRepository.UpdateInventory(inventoryVM);
            return inventory;
        }
    }
}
