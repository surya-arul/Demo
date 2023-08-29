using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApiDemo.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AlphabeticValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string inputValue = value.ToString();

                // Use a regular expression to match only alphabetic characters
                if (!Regex.IsMatch(inputValue, "^[a-zA-Z]*$"))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
