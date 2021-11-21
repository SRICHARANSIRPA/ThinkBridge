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

namespace Inventory.Application.Features.InventoryItems.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteItemCommand> _logger;

        public DeleteItemCommandHandler(IItemRepository itemRepository, IMapper mapper, ILogger<DeleteItemCommand> logger)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);
            if (itemToDelete == null)
            {
                //_logger.LogError("Item not exits in Database.");
                throw new NotFoundException(nameof(InventoryItem), request.Id);
            }
            await _itemRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"Item {itemToDelete.Id} is successfully Deleted.");

            return Unit.Value;

        }
    }
}
