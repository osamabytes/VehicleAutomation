using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderVM>> GetOrders();
        Task<IEnumerable<OrderVM>> GetOrdersByCustomer(string name);
        Task<OrderVM> GetOrderById(int id);
        Task<Order> CreateOrder(OrderVM order);
        Task<Order> UpdateOrder(OrderVM order);
        Task<bool> DeleteOrder(int id);
    }
}
