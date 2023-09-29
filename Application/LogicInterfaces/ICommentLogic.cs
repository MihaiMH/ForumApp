using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface ICommentLogic
{
    Task<Comment> CreateCommentAsync(CommentDto commentDto);
    Task<IEnumerable<Comment>?> GetCommentsByPost(int postId);
}