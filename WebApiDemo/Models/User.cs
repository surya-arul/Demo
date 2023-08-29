using System.ComponentModel.DataAnnotations;
using WebApiDemo.CustomAttributes;

namespace WebApiDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Avatar { get; set; }
    }
}
