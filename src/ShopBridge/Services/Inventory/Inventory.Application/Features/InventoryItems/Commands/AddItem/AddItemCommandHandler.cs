using AutoMapper;
using Inventory.Application.Contracts.Persistance;
using Inventory.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Commands.AddItem
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, int>
    {
        private readonly IItemRepository itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddItemCommandHandler> _logger;

        public AddItemCommandHandler(IItemRepository itemRepository, IMapper mapper, ILogger<AddItemCommandHandler> logger)
        {
            this.itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var itemEntity = _mapper.Map<InventoryItem>(request);
            var newItem = await itemRepository.AddAsync(itemEntity);
            _logger.LogInformation($"Order {newItem.Id} is successfully Created");
            return newItem.Id;
        }
    }
}
