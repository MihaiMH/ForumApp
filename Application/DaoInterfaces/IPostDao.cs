using Domain;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreatePostAsync(Post post);
    Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId);
    Task<Post> UpdatePostAsync(int postId, string title, string context);
    Task<bool> DeletePostAsync(int postId);
    Task<Post?> GetPostByIdAsync(int postId);
    Task<IEnumerable<Post>?> GetPostsByUser(string userName);
}