using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(PostDto postDto);
    Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId);
}