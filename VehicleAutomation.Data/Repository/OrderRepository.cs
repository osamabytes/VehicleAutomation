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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(OrderVM order)
        {
            var newOrder = new Order
            {
                CustomerName = order.CustomerName,
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status)
            };
            _context.Orders.Add(newOrder);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
                return null;
            return newOrder;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderVM> GetOrderById(int id)
        {
            var order = await _context.Orders.Select(x => new OrderVM
            {
                OrderId = x.Id,
                CustomerName = x.CustomerName,
                Status = x.Status.ToString()
            })
            .FirstOrDefaultAsync(x => x.OrderId == id);
            return order;
        }

        public async Task<IEnumerable<OrderVM>> GetOrders()
        {
            // pagination required to be applied
            var orders = await _context.Orders.Select(x => new OrderVM
            {
                OrderId = x.Id,
                CustomerName = x.CustomerName,
                Status = x.Status.ToString()
            }).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrderVM>> GetOrdersByCustomer(string name)
        {
            // pagination needs to be applied
            var orders = await _context.Orders.Select(x => new OrderVM
            {
                OrderId = x.Id,
                CustomerName = x.CustomerName,
                Status = x.Status.ToString()
            }).Where(x => x.CustomerName.Contains(name))
            .ToListAsync();
            return orders;
        }

        public async Task<Order> UpdateOrder(OrderVM order)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == order.OrderId);
            if (existingOrder == null)
                return null;
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), order.Status);
            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
            return existingOrder;
        }
    }
}
