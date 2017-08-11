
using FluentValidation.Attributes;
using NXS.Core.Validations;

[Validator(typeof(CredentialsValidator))]
public class CredentialsResource
{
        public string UserName { get; set; }
        public string Password { get; set; }   
}