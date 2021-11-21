using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems
{
    public class GetInventoryItemsQuery : IRequest<List<InventoryItemsVM>>
    {
        public string Name { get; set; }

        public GetInventoryItemsQuery(string name)
        {
            Name = name;
        }
    }
}
