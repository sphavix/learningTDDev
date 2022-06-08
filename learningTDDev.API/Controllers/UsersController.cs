using learningTDDev.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace learningTDDev.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _userService;

    public UsersController(IUsersService userService)
    {
        this._userService = userService;
    }
   

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
}
