using Inventory.Application.Contracts.Persistance;
using Inventory.InfraStructure.Persistance;
using Inventory.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.InfraStructure
{
    public static class InfraStructureServiceRegistrations
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InventoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
