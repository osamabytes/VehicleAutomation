using VehicleAutomation.WebUI.Enum;

namespace VehicleAutomation.WebUI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public OrderStatusEnum Status { get; set; }
    }
}
