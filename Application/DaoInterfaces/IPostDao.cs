using Domain;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreatePostAsync(Post post);
    Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId);
}