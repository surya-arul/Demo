using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// GET: /user?page=*$per_page=*
        /// Get all user details from the database
        /// </summary>
        /// <returns>Return all the user members</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(int page,int per_page)
        {
            try
            {
                List<User> userList = await _userService.GetAllUsers(page,per_page);
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred in the process..{ex}");
            }
        }

        /// <summary>
        /// GET: /user/2
        /// Get user details by id
        /// </summary>
        /// <returns>Return all the user members</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                User user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred in the process..{ex}");
            }
        }

        /// <summary>
        /// POST: /user
        /// </summary>
        /// <param name="userInput">The user object to be inserted</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserInput userInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUser = await _userService.CreateUser(userInput);

                var response = new
                {
                    name = createdUser.Name,
                    job = createdUser.Job,
                    id = createdUser.Id,
                    createdAt = createdUser.CreatedAt
                };

                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred in the process..");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
