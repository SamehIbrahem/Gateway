using GatewayTask.Repo.Data;
using GatewayTask.Service;
using GatewayTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayTask.Web
{
    public static class ConfigureContainerExtensions
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
            string dataConnectionString)
        {
            serviceCollection.AddDbContext<GatewayContext>(options =>
                options.UseSqlServer(dataConnectionString));

        }

        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGatewayService, GatewayService>();
            serviceCollection.AddTransient<IDeviceService, DeviceService>();

        }

    }
}
