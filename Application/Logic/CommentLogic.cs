using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ICommentDao _commentDao;

    public CommentLogic(ICommentDao commentDao)
    {
        _commentDao = commentDao;
    }
    
    public async Task<Comment> CreateCommentAsync(CommentDto commentDto)
    {
        ValidateData(commentDto);
        Comment toCreate = new Comment(commentDto.User, commentDto.Context, commentDto.Post);
        Comment created = await _commentDao.CreateCommentAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<Comment>?> GetCommentsByPost(int postId)
    {
        return _commentDao.GetCommentsByPost(postId);
    }

    public static void ValidateData(CommentDto commentDto)
    {
        string context = commentDto.Context;

        if (string.IsNullOrWhiteSpace(context))
        {
            throw new Exception("Comment can't be empty or only with white spaces");
        }

        if (context.Length > 100)
        {
            throw new Exception("Comment can be maximum 100 characters length");
        }
    }
}