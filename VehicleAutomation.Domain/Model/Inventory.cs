using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Enum;

namespace VehicleAutomation.Domain.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public InventoryType ComponentType { get; set; }
        public int Quantity { get; set; }
    }
}
