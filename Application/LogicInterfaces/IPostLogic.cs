using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(PostDto postDto);
    Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId);
    Task<Post> UpdatePostAsync(PostUpdateDto postUpdateDto);
    Task<bool> DeletePostAsync(int postId);
    Task<Post?> GetPostByIdAsync(int postId);
}