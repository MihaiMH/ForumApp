using Domain;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    public Task<Comment> CreateCommentAsync(Comment comment);
    public Task<IEnumerable<Comment>?> GetCommentsByPost(int postId);

    public Task<Comment?> GetCommentById(int commentId);

    public Task<Comment> UpdateComment(int oldCommentId, String newContext);
    public Task<bool> DeleteComment(int commentId);
}