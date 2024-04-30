﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;
using VehicleAutomation.Domain.ViewModel;

namespace VehicleAutomation.Mediator.Query
{
    public class UpdateOrderQuery : IRequest<Order>
    {
        public OrderVM OrderVM { get; set; }
        public UpdateOrderQuery(OrderVM orderVM)
        {
            OrderVM = orderVM;
        }
    }
}
