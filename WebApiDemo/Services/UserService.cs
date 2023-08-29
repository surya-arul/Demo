using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;
using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        /// <summary>
        /// Getting all users
        /// </summary>
        /// <param name="page">Page number to view</param>
        /// <param name="per_page">Contents should show per page</param>
        /// <returns> Getting all users</returns>
        public async Task<List<User>> GetAllUsers(int page,int per_page)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}/users?page={page}&per_page={per_page}";

                HttpResponseMessage responseMessage = await client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                string content = await responseMessage.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                var responseObject = JsonConvert.DeserializeObject<JObject>(content);
                var userDataArray = responseObject["data"].ToObject<JArray>();

                // Deserialize the user data
                List<User> userList = userDataArray.ToObject<List<User>>();
                return userList;
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Getting user by id</returns>
        public async Task<User> GetUserById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}/users/{id}";

                HttpResponseMessage responseMessage = await client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                string content = await responseMessage.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                var responseObject = JsonConvert.DeserializeObject<JObject>(content);
                var userData = responseObject["data"].ToObject<User>();
                return userData;
            }
        }

        /// <summary>s
        /// Createing user
        /// </summary>
        /// <param name="userInput">Inserting user values as a object</param>
        /// <returns>Returning response</returns>
        public async Task<CreateUserResponse> CreateUser(UserInput userInput)
        {
            using (HttpClient client = new HttpClient())
            {

                string url = $"{baseUrl}/users";

                string jsonContent = JsonConvert.SerializeObject(userInput);
                HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(url, httpContent);
                responseMessage.EnsureSuccessStatusCode();

                string content = await responseMessage.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                CreateUserResponse createUserResponse = JsonConvert.DeserializeObject<CreateUserResponse>(content);
                return createUserResponse;
            }
        }



    }
}
