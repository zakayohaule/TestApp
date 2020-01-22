using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace TestApp.Http.Requests
{
    public class UpdatePostRequest
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
    }

    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                /*.When(req => req.Name != null)
                    .WithMessage("{PropertyName} is required")
                .MinimumLength(20)
                    .WithMessage("This value should at least have 20 characters")
                .EmailAddress()
                    .WithMessage("Provide a valid email address")*/;
        }
    }
}