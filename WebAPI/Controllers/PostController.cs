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
    [Route("/GetPostsBySubForum")]
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

    [HttpGet]
    [Route("/GetPostById")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPostById([FromQuery] int postId)
    {
        try
        {
            Post? post = await postLogic.GetPostByIdAsync(postId);
            return Created($"/posts/{postId}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("/GetPostsByUser")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPostByUser([FromQuery] string userName)
    {
        try
        {
            IEnumerable<Post>? posts = await postLogic.GetPostsByUser(userName);
            return Created($"/user/{userName}/posts", posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<Post>> UpdatePostAsync(PostUpdateDto dto)
    {
        try
        {
            Post post = await postLogic.UpdatePostAsync(dto);
            return Created($"/subforums/{dto.Post.Subforum.Id}/posts/{dto.Post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteComment(int postId)
    {
        try
        {
            bool ok = await postLogic.DeletePostAsync(postId);
            if (ok)
            {
                return Ok();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}