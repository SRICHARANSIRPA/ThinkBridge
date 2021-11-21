﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; set; }

    }
}
