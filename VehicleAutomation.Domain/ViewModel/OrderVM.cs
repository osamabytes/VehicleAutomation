using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleAutomation.Domain.ViewModel
{
    public class OrderVM
    {
        public int? OrderId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
