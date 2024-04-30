using VehicleAutomation.WebUI.Enum;

namespace VehicleAutomation.WebUI.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public InventoryTypeEnum ComponentType { get; set; }
        public int Quantity { get; set; }
    }
}
