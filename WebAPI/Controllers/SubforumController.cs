using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubforumController : ControllerBase
{
    private readonly ISubforumLogic _subforumLogic;

    public SubforumController(ISubforumLogic subforumLogic)
    {
        _subforumLogic = subforumLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Subforum>> CreateAsync(SubforumDto dto)
    {
        try
        {
            Subforum subforum = await _subforumLogic.CreateAsync(dto);
            return Created($"/subforums/{subforum.Id}", subforum);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}