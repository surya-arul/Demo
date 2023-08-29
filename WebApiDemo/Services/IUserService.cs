using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers(int page,int per_page);

        Task<User> GetUserById(int id);

        Task<CreateUserResponse> CreateUser(UserInput userInput);
    }
}
