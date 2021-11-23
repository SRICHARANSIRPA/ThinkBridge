using Inventory.Application.Features.InventoryItems.Commands.AddItem;
using Inventory.Application.Features.InventoryItems.Commands.UpdateItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems;

namespace Inventory.Application.Services
{
    public interface IInventoryService
    {
        Task<int> AddItem(AddItemCommand command);
        Task<Unit> UpdateItem(UpdateItemCommand command);
        Task<Unit> DeleteItem(int id);
        Task<IEnumerable<InventoryItemsVM>> GetAllItems();
        Task<IEnumerable<InventoryItemsVM>> GetItemByName(string itemName);
    }
}
