using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ICommentDao _commentDao;
    private readonly IUserDao userDao;
    private readonly IPostDao postDao;

    public CommentLogic(ICommentDao commentDao, IUserDao userDao, IPostDao postDao)
    {
        _commentDao = commentDao;
        this.userDao = userDao;
        this.postDao = postDao;
    }

    public async Task<Comment> CreateCommentAsync(CommentDto commentDto)
    {
        ValidateData(commentDto);
        User? user = await userDao.GetByUsernameAsync(commentDto.User);
        Post? post = await postDao.GetPostByIdAsync(commentDto.PostId);
        Comment toCreate = new Comment
        {
            User = user,
            Context = commentDto.Context,
            Post = post
        };
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
        Comment? comment = await _commentDao.GetCommentById(updateCommentDto.OldCommentId);
        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        comment.Context = updateCommentDto.NewContext;
        return await _commentDao.UpdateComment(comment);
    }

    public async Task<bool> DeleteComment(int commentId)
    {
        Comment? comment = await _commentDao.GetCommentById(commentId);
        if (comment == null)
        {
            throw new Exception("Comment not found");
        }

        return await _commentDao.DeleteComment(comment);
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