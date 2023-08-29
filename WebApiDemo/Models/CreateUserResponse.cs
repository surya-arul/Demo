namespace WebApiDemo.Models
{
    public class CreateUserResponse
    {
        public string? Name { get; set; }
        public string? Job { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
