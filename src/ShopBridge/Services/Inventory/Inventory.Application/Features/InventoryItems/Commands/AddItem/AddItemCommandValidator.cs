using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Features.InventoryItems.Commands.AddItem
{
    public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Category)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Category} is required.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Description} is required.");

            RuleFor(p => p.ImageFile)
                .NotEmpty()
                .NotNull()
                .WithMessage("{Description} is required.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{Price} must be greater than Zero.");
        }
    }
}
