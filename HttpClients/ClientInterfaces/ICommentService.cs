using Domain;

namespace HttpClients.ClientInterfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsByPostAsync(string postId);
}