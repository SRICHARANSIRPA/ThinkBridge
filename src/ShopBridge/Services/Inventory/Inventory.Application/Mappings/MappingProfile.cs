using AutoMapper;
using Inventory.Application.Features.InventoryItems.Commands.AddItem;
using Inventory.Application.Features.InventoryItems.Commands.UpdateItem;
using Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems;
using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InventoryItem, InventoryItemsVM>().ReverseMap();
            CreateMap<InventoryItem, AddItemCommand>().ReverseMap();
            CreateMap<InventoryItem, UpdateItemCommand>().ReverseMap();
        }
    }
}
