using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentLogic commentLogic;

    public CommentController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    [Route("CreateComment")]
    public async Task<ActionResult<Comment>> CreateCommentAsync(CommentDto dto)
    {
        try
        {
            Comment comment = await commentLogic.CreateCommentAsync(dto);
            return Created($"/posts/{dto.Post.Id}/comments/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("GetCommentsByPost")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByPost(int postId)
    {
        try
        {
            IEnumerable<Comment>? comments = await commentLogic.GetCommentsByPost(postId);
            return Created($"/posts/{postId}/comments/", comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}