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
using Inventory.Application.Services;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController: Controller
    {
        //private readonly IMediator _mediator;
        private readonly IInventoryService _inventoryService;

        public ItemController(IInventoryService inventoryService)
        {
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        [HttpGet("{itemName}", Name = "GetItem")]
        [ProducesResponseType(typeof(IEnumerable<InventoryItemsVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoryItemsVM>>> GetItemByName(string itemName)
        {
            var query = new GetInventoryItemsQuery(itemName);
            var items = await _inventoryService.GetItemByName(itemName);
            return Ok(items);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InventoryItemsVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InventoryItemsVM>>> GetAllItems()
        {
            var items = await _inventoryService.GetAllItems();
            return Ok(items);
        }


        [HttpPost(Name = "AddItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddItem([FromBody] AddItemCommand command)
        {
            var result = await _inventoryService.AddItem(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            var result = await _inventoryService.UpdateItem(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var result = await _inventoryService.DeleteItem(id);

            result.Equals(Unit.Value);
            return NoContent();
        }
    }
}
