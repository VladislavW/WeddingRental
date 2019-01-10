using FluentValidation;
using WeddingRental.Models.Views.User;

namespace WeddingRental.Models.User.Validators
{
    public class SignUpValidator: AbstractValidator<SignUpModel> 
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();
            
            RuleFor(x => x.Password)
                .NotNull()
                .Length(8);
            
            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .Length(8)
                .Equal(d => d.Password);
        }
    }
}