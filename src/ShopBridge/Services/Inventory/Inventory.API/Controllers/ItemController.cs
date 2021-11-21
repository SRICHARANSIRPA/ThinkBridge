using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems;
using Microsoft.AspNetCore.Http;
using Inventory.Application.Features.InventoryItems.Commands.UpdateItem;
using Inventory.Application.Features.InventoryItems.Commands.DeleteItem;
using Inventory.Application.Features.InventoryItems.Commands.AddItem;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController: Controller
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{itemName}", Name = "GetItem")]
        [ProducesResponseType(typeof(IEnumerable<InventoryItemsVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoryItemsVM>>> GetItemByName(string itemName)
        {
            var query = new GetInventoryItemsQuery(itemName);
            var items = await _mediator.Send(query);
            return Ok(items);
        }



        [HttpPost(Name = "AddItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddItem([FromBody] AddItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var command = new DeleteItemCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
