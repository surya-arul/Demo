using System.ComponentModel.DataAnnotations;
using WebApiDemo.CustomAttributes;

namespace WebApiDemo.Models
{
    public class UserInput
    {
        [Required(ErrorMessage = "The Job field is required")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "The Job field must contain only alphabetic characters.")]
        public string? Job { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        [AlphabeticValidation(ErrorMessage = "The Name field must contain only alphabetic characters.")]
        public string? Name { get; set; }
    }
}
