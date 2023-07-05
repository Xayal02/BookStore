using BookStore.Models;
using FluentValidation;

namespace BookStore.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(3).WithMessage("Must at be at least 3 character")
                .MaximumLength(30).WithMessage("Must be not greather than 30 characters");

            RuleFor(c => c.DisplayOrder)
                .InclusiveBetween(1, 100).WithMessage("Order must be between 1 and 100");
                
        }
    }
}
