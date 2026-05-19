using FluentValidation;
using SlugApi.DTOs;

namespace SlugApi.Validators
{
    public class GenerateSlugRequestValidator : AbstractValidator<GenerateSlugRequest>
    {
        public GenerateSlugRequestValidator()
        {
             RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Text cannot be empty")
            .MaximumLength(499).WithMessage("Text must be under 500 characters");

            RuleFor(x => x.Separator)
            .Must(MustbeHyphenOrUnderscore).WithMessage("Separator must be Hyphen or  Underscore character");

        }

        private bool MustbeHyphenOrUnderscore(char? value) => value == '-' || value == '_' || value == null;
        
          
        
    }
}
