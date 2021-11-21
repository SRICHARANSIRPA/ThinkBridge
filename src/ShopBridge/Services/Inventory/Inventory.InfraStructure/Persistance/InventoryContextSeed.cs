using Inventory.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.InfraStructure.Persistance
{
    public class InventoryContextSeed
    {
        public static async Task SeedAsync(InventoryContext inventoryContext, ILogger<InventoryContextSeed> logger)
        {
            if (!inventoryContext.InventoryItems.Any())
            {
                inventoryContext.InventoryItems.AddRange(getPreConfiguredOrders());
                await inventoryContext.SaveChangesAsync();
                logger.LogInformation("Seed database Associated with Context {DbContextName}", typeof(InventoryContext).Name);
            }
        }
        private static IEnumerable<InventoryItem> getPreConfiguredOrders()
        {
            return new List<InventoryItem>
            {
                //new InventoryItem(){ UserName = "swn", FirstName="SriCharan" , LastName="Sirpa" , EmailAddress="charanchery9989@gmail.com" , AddressLine = "Shivaji nagar" , Country="India",TotalPrice=350 }

            };
        }
    }
}
