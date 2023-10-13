using Domain;

namespace HttpClients.ClientInterfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsByPostAsync(string postId);
    Task<Comment> CreateCommentAsync(string user, string context, int postId);
}