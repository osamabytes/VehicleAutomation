﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Domain.Model;

namespace VehicleAutomation.Data.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> InventoryComponents { get; set; }
    }
}
