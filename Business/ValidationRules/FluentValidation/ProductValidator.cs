using Business.Constants;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.ProductName).Length(2, 35);

        RuleFor(p => p.UnitPrice).NotEmpty();
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
        RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1);

        
    }
}