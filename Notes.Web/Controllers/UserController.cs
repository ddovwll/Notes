using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Notes.Core.Interfaces;
using Notes.Web.Mappers;
using Notes.Web.Models.RequestModels;

namespace Notes.Web.Controllers;

public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
    {
        await userService.SaveAsync(UserRequestToUser.Map(userRequest));

        return Ok();
    }
}