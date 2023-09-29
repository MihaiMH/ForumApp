using Domain;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
    public Task<Comment> CreateCommentAsync(Comment comment);
    public Task<IEnumerable<Comment>?> GetCommentsByPost(int postId);
}