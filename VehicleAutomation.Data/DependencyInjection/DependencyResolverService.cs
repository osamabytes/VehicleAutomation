using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAutomation.Data.Data;

namespace VehicleAutomation.Data.DependencyInjection
{
    public static class DependencyResolverService
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            return services;
        }
    }
}
