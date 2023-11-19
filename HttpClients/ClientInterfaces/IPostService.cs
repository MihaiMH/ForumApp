using Domain;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPostsBySubforumAsync(string subForumId);
    Task<Post> GetPostById(string postId);

    Task<IEnumerable<Post>> GetPostsByUserAsync(string userName);

    Task<Post> CreatePostAsync(int subforumId, string title, string context, User user);
}