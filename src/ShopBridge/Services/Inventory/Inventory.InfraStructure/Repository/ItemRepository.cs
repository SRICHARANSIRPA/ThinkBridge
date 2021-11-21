using Inventory.Application.Contracts.Persistance;
using Inventory.Domain.Entities;
using Inventory.InfraStructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.InfraStructure.Repository
{
    public class ItemRepository : BaseRepository<InventoryItem>, IItemRepository
    {
        public ItemRepository(InventoryContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<InventoryItem>> GetItemByName(string name)
        {
            var itemList = await _dbContext.InventoryItems
                                .Where(o => o.Name == name)
                                .ToListAsync();
            return itemList;
        }
    }
}
