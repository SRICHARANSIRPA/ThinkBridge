using AutoMapper;
using Inventory.Application.Contracts.Persistance;
using Inventory.Application.Exceptions;
using Inventory.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Commands.UpdateItem
{
    class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateItemCommand> _logger;

        public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper, ILogger<UpdateItemCommand> logger)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            //update the order
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.Id);
            if (itemToUpdate == null)
            {
                //_logger.LogError("Order not exits in Database.");
                throw new NotFoundException(nameof(InventoryItem), request.Id);

            }

            _mapper.Map(request, itemToUpdate, typeof(UpdateItemCommand), typeof(InventoryItem));

            await _itemRepository.UpdateAsync(itemToUpdate);

            _logger.LogInformation($"Item {itemToUpdate.Id} is successfully updated");

            return Unit.Value;
        }
    }
}
