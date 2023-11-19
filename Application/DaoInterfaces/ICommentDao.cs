using Domain;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    public Task<Comment> CreateCommentAsync(Comment comment);
    public Task<IEnumerable<Comment>?> GetCommentsByPost(int postId);

    public Task<Comment?> GetCommentById(int commentId);

    public Task<Comment> UpdateComment(Comment comment);
    public Task<bool> DeleteComment(Comment comment);
}