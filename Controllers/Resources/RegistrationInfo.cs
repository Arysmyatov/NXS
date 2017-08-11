
using FluentValidation.Attributes;
using NXS.Core.Validations;

namespace NXS.Controllers.Resources
{
    [Validator(typeof(RegistrationInfoValidator))]
    public class RegistrationInfoResource 
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
}