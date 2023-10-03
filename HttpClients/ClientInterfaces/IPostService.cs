using Domain;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPostsBySubforumAsync(string subForumId);
    Task<Post> GetPostById(string postId);
}