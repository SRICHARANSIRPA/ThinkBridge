using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Contracts.Persistance
{
    public interface IItemRepository : IAsyncRepository<InventoryItem>
    {
        Task<IEnumerable<InventoryItem>> GetItemByName(string name);
    }
}
