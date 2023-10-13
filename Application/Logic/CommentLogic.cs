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
        User user = new User(commentDto.User, "", "");
        Post post = new Post("", new Subforum("", new User("", "", "")), "", new User("", "", ""));
        post.Id = commentDto.PostId;
        Comment toCreate = new Comment(user, commentDto.Context, post);
        Comment created = await _commentDao.CreateCommentAsync(toCreate);
        return created;
    }

    public async Task<IEnumerable<Comment>?> GetCommentsByPost(int postId)
    {
        return await _commentDao.GetCommentsByPost(postId);
    }

    public async Task<Comment> UpdateComment(UpdateCommentDto updateCommentDto)
    {
        ValidateData(updateCommentDto);
        return  await _commentDao.UpdateComment(updateCommentDto.OldCommentId, updateCommentDto.NewContext);
    }

    public async Task<bool> DeleteComment(int commentId)
    {
        return await _commentDao.DeleteComment(commentId);
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
    
    public static void ValidateData(UpdateCommentDto commentDto)
    {
        string context = commentDto.NewContext;

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