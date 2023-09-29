using System.Collections;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePostAsync(PostDto dto)
    {
        try
        {
            Post post = await postLogic.CreatePostAsync(dto);

            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPostsBySubForumAsync([FromQuery] int subForumId)
    {
        try
        {
            IEnumerable<Post>? posts = await postLogic.GetPostsBySubForumAsync(subForumId);
            return Created($"/subforums/{subForumId}/posts", posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}