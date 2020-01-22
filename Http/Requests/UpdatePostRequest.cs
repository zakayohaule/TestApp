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
                .NotNull();
        }
    }
}