using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace TestApp.ViewModels
{
    public class LoginModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
//            CascadeMode = CascadeMode.Continue;

            RuleFor(lm => lm.Email).NotNull().NotEmpty().WithMessage("email can't be null, from fluentvalidator");
            RuleFor(lm => lm.Password).NotNull().NotEmpty();
        }
    }
}