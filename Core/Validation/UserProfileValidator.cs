using FluentValidation;
using NXS.Controllers.Resources;

namespace NXS.Core.Validation
{
    public class UserProfileValidator  : AbstractValidator<UserProfileResource>
    {
        public UserProfileValidator()
        {
            RuleFor(up => up.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(up => up.LastName).NotEmpty().WithMessage("LastName cannot be empty");
        }  
    }
}