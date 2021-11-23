using Inventory.Application.Features.InventoryItems.Commands.AddItem;
using Inventory.Application.Features.InventoryItems.Commands.DeleteItem;
using Inventory.Application.Features.InventoryItems.Commands.UpdateItem;
using Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMediator _mediator;

        public InventoryService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<int> AddItem(AddItemCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<Unit> DeleteItem(int id)
        {
            var command = new DeleteItemCommand() { Id = id };
            var result = await _mediator.Send(command);
            return result;
        }
        public async Task<Unit> UpdateItem(UpdateItemCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task<IEnumerable<InventoryItemsVM>> GetAllItems()
        {
            var query = new GetInventoryItemsQuery();
            var items = await _mediator.Send(query);
            return items;
        }

        public async Task<IEnumerable<InventoryItemsVM>> GetItemByName(string itemName)
        {
            var query = new GetInventoryItemsQuery(itemName);
            var items = await _mediator.Send(query);
            return items;
        }

    }
}
