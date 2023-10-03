using System.Collections;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
    {
        try
        {
            User user = await userLogic.CreateAsync(dto);
            return Created($"/users/{user.Username}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/GetByUserName")]
    public async Task<ActionResult<User>> GetByUserNameAsync([FromQuery] string userName)
    {
        try
        {
            User? user = await userLogic.GetByUsernameAsync(userName);
            return Created($"/users/{user.Username}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/GetAllUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        try
        {
            IEnumerable<User>? users = await userLogic.GetAllUsers();
            return Created($"/users", users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}