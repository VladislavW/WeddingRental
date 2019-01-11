using FluentValidation;
using WeddingRental.Models.User.From;

namespace WeddingRental.Models.User.Validators
{
    public class SignInValidator : AbstractValidator<SignInModel>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull();
        }
    }
}