using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LogInController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public LogInController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult<User>> LogInAsync(LogInDto dto)
    {
        try
        {
            User user = await userLogic.Login(dto);
            if (user != null)
            {
                return Created($"/users/{user.Username}", user);
            }

            return Created($"/users/notfound", null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}