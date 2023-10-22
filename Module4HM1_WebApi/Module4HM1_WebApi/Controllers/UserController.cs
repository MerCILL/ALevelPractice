using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponseListModel>> GetUsersAsync(
            [FromQuery] int page = 1,
            [FromQuery] int delay = 0)
        {
            if (delay > 0)
                await Task.Delay(delay * 1000);

            var usersResponse = await _userService.GetUsersAsync(page);

            return Ok(usersResponse);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUserAsync(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] ChangeCreateUserModel createUser)
        {
            var checkEmail = await _userService.CheckEmail(createUser.Email);
            if (checkEmail == true) return BadRequest();

            var user = new User(createUser.FirstName, createUser.LastName, createUser.Email);

            var isCreated = await _userService.CreateAsync(user);
            if (!isCreated) return BadRequest();

            return CreatedAtAction("GetUser", new { id = user.Id }, new {user.Id, user.FirstName, user.LastName, user.Email, DateTime.UtcNow});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            var isDeleted = await _userService.DeleteAsync(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(
            int id, 
            [FromBody] ChangeCreateUserModel changeCreateUserModel)
        {
            var updatedUser = await _userService.UpdateAsync(id, changeCreateUserModel);
            if (updatedUser == null) return NotFound();

            return Ok(new {updatedUser, DateTime.UtcNow});
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserPatchAsync(
            int id,
            [FromBody] JsonPatchDocument<ChangeCreateUserModel> patchDocument)
        {
            if (patchDocument == null) return BadRequest(ModelState);

            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();

            var userToPatch = new ChangeCreateUserModel
            { 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                Email = user.Email 
            };

            patchDocument.ApplyTo(userToPatch);
            var updatedUser = await _userService.UpdateAsync(user.Id, userToPatch);

            return Ok(new {user, DateTime.UtcNow});

        }   

    }
}
