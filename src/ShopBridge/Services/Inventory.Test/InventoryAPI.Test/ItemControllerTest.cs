using Inventory.API.Controllers;
using Inventory.Application.Contracts.Persistance;
using Inventory.Application.Features.InventoryItems.Commands.AddItem;
using Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems;
using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InventoryAPI.Test
{
    public class ItemControllerTest
    {

        public ItemControllerTest()
        {
            Mock = new Mock<IInventoryService>();
            ItemController = new ItemController(Mock.Object);
        }

        public Mock<IInventoryService> Mock;

        public ItemController ItemController;
        [Fact]
        public async Task TestAddItemControllerAsync()
        {
            var actionResult = await ItemController.AddItem(GetSampleItem());
            var result = actionResult.Value as int?;
            Assert.IsType<ActionResult<int>>(actionResult);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGetItemController()
        {
            var actionResult = await ItemController.GetItemByName(GetSampleItem().Name);
            var result = actionResult.Value as IEnumerable<InventoryItemsVM>;
            Assert.IsType<ActionResult<IEnumerable<InventoryItemsVM>>>(actionResult);
            Assert.NotNull(result);
        }

        private AddItemCommand GetSampleItem()
        {
            return new AddItemCommand
            { 
                Category = "School Bag",
                Description = "Red School Bag with 5 Zips",
                Name = "FastTrack",
                Price = 10.5M,
                ImageFile="School Bag image",
                Summary = "School Bag Summary"
            };
        }

    }
}
