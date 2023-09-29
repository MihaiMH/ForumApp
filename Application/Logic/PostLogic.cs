using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao _postDao;

    public PostLogic(IPostDao postDao)
    {
        _postDao = postDao;
    }

    public async Task<Post> CreatePostAsync(PostDto postDto)
    {
        ValidateData(postDto);
        Post toCreate = new Post(postDto.Title, postDto.Subforum, postDto.Context, postDto.Author);
        toCreate.Id = postDto.Id;
        Post created = await _postDao.CreatePostAsync(toCreate);
        return created;
    }

    public async Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId)
    {
        return await _postDao.GetPostsBySubForumAsync(subForumId);
    }

    public static void ValidateData(PostDto postDto)
    {
        string title = postDto.Title;
        string context = postDto.Context;


        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(context))
        {
            throw new Exception("Title and context cannot be empty or only with white spaces");
        }

        if (title.Length < 5)
        {
            throw new Exception("The title must be longer than 5 characters");
        }

        if (title.Length > 50)
        {
            throw new Exception("The title must be shorter than 51 characters");
        }

        if (context.Length > 500)
        {
            throw new Exception("The context must be shorter than 500 characters");
        }
    }
}