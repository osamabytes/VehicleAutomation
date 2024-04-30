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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(OrderVM orderVM)
        {
            var order = await _orderRepository.CreateOrder(orderVM);
            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteOrder(id);
            return result;
        }

        public async Task<OrderVM> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            return order;
        }

        public async Task<List<OrderVM>> GetOrderList()
        {
            var orders = await _orderRepository.GetOrders();
            return orders.ToList();
        }
        public async Task<List<OrderVM>> GetOrdersListByCustomer(string customerName)
        {
            var orders = await _orderRepository.GetOrdersByCustomer(customerName);
            return orders.ToList();
        }

        public async Task<Order> UpdateOrder(OrderVM orderVM)
        {
            var order = await _orderRepository.UpdateOrder(orderVM);
            return order;
        }
    }
}
