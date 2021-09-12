using System;

namespace IceCreamFramework.Validation
{
    public interface IValidationRule
    {
        bool Validation();
    }


    public class ValidationAttribute : Attribute
    {
        private readonly IValidationRule _rule;


        public ValidationAttribute(IValidationRule rule)
        {
            _rule = rule;
        }
    }
}
