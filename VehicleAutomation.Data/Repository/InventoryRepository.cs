using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Data.Data;
using VehicleAutomation.Domain.Enum;
using VehicleAutomation.Domain.IRepository;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Data.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> CreateBulkInventory(List<InventoryVM> inventoryItems)
        {
            var newInventoryItems = inventoryItems.Select(x => new Inventory
            {
                ComponentType = (InventoryType)Enum.Parse(typeof(InventoryType), x.ComponentType),
                Quantity = x.Quantity
            });
            if (!newInventoryItems.Any())
                return null;
            await _context.InventoryComponents.AddRangeAsync(newInventoryItems);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return newInventoryItems;
        }

        public async Task<Inventory> CreateInventory(InventoryVM inventoryVM)
        {
            var newInventoryItem = new Inventory
            {
                ComponentType = (InventoryType)Enum.Parse(typeof(InventoryType), inventoryVM.ComponentType),
                Quantity = inventoryVM.Quantity
            };
            _context.InventoryComponents.Add(newInventoryItem);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return newInventoryItem;
        }

        public async Task<bool> DeleteInventory(int id)
        {
            var inventory = await _context.InventoryComponents.FirstOrDefaultAsync(x => x.Id == id);
            if (inventory == null)
                return false;
            _context.InventoryComponents.Remove(inventory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<InventoryVM> GetInventoryById(int id)
        {
            var inventory = await _context.InventoryComponents.Select(x => new InventoryVM
            {
                Id = x.Id,
                ComponentType = x.ComponentType.ToString(),
                Quantity = x.Quantity
            }).FirstOrDefaultAsync(x => x.Id == id);
            return inventory;
        }

        public async Task<IEnumerable<InventoryVM>> GetInventoryByType(string type)
        {
            var inventoryItems = await _context.InventoryComponents
                .Where(x => x.ComponentType == (InventoryType)Enum.Parse(typeof(InventoryType), type))
                .Select(x => new InventoryVM
            {
                Id = x.Id,
                ComponentType = x.ComponentType.ToString(),
                Quantity = x.Quantity
            }).ToListAsync();
            return inventoryItems;
        }

        public async Task<IEnumerable<InventoryVM>> GetInventoryItems()
        {
            var inventoryItems = await _context.InventoryComponents
                .Select(x => new InventoryVM
                {
                    Id = x.Id,
                    ComponentType = x.ComponentType.ToString(),
                    Quantity = x.Quantity
                }).ToListAsync();
            return inventoryItems;
        }

        public async Task<Inventory> UpdateInventory(InventoryVM inventoryVM)
        {
            var existingInventory = await _context.InventoryComponents.FirstOrDefaultAsync(x => x.Id == inventoryVM.Id);
            if (existingInventory == null)
                return null;
            existingInventory.ComponentType = (InventoryType)Enum.Parse(typeof(InventoryType), inventoryVM.ComponentType);
            existingInventory.Quantity = inventoryVM.Quantity;
            await _context.SaveChangesAsync();
            return existingInventory;
        }
    }
}
