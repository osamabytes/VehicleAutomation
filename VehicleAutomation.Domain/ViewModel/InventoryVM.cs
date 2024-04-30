using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAutomation.Domain.ViewModel
{
    public class InventoryVM
    {
        public int Id { get; set; }
        [Required]
        public string ComponentType { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
