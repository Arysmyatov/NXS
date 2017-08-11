using FluentValidation;
using NXS.Controllers.Resources;

namespace NXS.Core.Validations
{
    public class RegistrationInfoValidator : AbstractValidator<RegistrationInfoResource>
    {
        public RegistrationInfoValidator()
        {
            RuleFor(ri => ri.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(ri => ri.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(ri => ri.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(ri => ri.LastName).NotEmpty().WithMessage("LastName cannot be empty");
        }
    }
}