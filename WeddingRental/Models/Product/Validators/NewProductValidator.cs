using FluentValidation;
using WeddingRental.Models.Product.From;

namespace WeddingRental.Models.Product.Validators
{
    public class NewProductValidator : AbstractValidator<NewProductModel>
    {
        public NewProductValidator()
        {
            RuleFor(x => x.ProductColor)
                .IsInEnum();
            
            RuleFor(x => x.Type)
                .IsInEnum(); 
            
            RuleFor(x => x.ProductNumber)
                .Length(100);
            
            RuleFor(x => x.ProductName)
                .Length(5000);
        }
        
    }
}