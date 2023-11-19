using Domain;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreatePostAsync(Post post);
    Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId);
    Task<Post> UpdatePostAsync(Post post);
    Task<bool> DeletePostAsync(Post post);
    Task<Post?> GetPostByIdAsync(int postId);
    Task<IEnumerable<Post>?> GetPostsByUser(string userName);
}