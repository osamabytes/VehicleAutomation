using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Domain.IService
{
    public interface IOrderService
    {
        Task<List<OrderVM>> GetOrderList();
        Task<List<OrderVM>> GetOrdersListByCustomer(string customerName);
        Task<OrderVM> GetOrderById(int id);
        Task<Order> CreateOrder(OrderVM orderVM);
        Task<Order> UpdateOrder(OrderVM orderVM);
        Task<bool> DeleteOrder(int id);
    }
}
