using AutoMapper;
using Inventory.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Queries.GetInventoryItems
{
    public class GetInventoryItemsQueryHandler : IRequestHandler<GetInventoryItemsQuery, List<InventoryItemsVM>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetInventoryItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<InventoryItemsVM>> Handle(GetInventoryItemsQuery request, CancellationToken cancellationToken)
        {
            var itemList = await _itemRepository.GetItemByName(request.Name);
            return _mapper.Map<List<InventoryItemsVM>>(itemList);
        }
    }
}
