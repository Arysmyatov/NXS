
using FluentValidation.Attributes;
using NXS.Core.Validation;
using NXS.Core.Validations;

namespace NXS.Controllers.Resources
{
    [Validator(typeof(UserProfileValidator))]
    public class UserProfileResource
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
    }
}