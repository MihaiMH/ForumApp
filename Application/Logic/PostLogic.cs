using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao _postDao;
    private readonly IUserDao userDao;
    private readonly ISubforumDao subforumDao;

    public PostLogic(IPostDao postDao, IUserDao userDao, ISubforumDao subforumDao)
    {
        _postDao = postDao;
        this.userDao = userDao;
        this.subforumDao = subforumDao;
    }

    public async Task<Post> CreatePostAsync(PostDto postDto)
    {
        ValidateData(postDto);
        Subforum? subforum = await subforumDao.GetByIdAsync(postDto.SubforumId);
        Console.WriteLine("TEST1  " + postDto.Author.Username);
        User? user = await userDao.GetByUsernameAsync(postDto.Author.Username);
        Console.WriteLine(user.Username);
        Post toCreate = new Post
        {
            Id = 0,
            Title = postDto.Title,
            Subforum = subforum,
            Context = postDto.Context,
            Author = user
        };
        Post created = await _postDao.CreatePostAsync(toCreate);
        return created;
    }

    public async Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId)
    {
        return await _postDao.GetPostsBySubForumAsync(subForumId);
    }

    public async Task<Post> UpdatePostAsync(PostUpdateDto postUpdateDto)
    {
        ValidateData(postUpdateDto);
        return await _postDao.UpdatePostAsync(postUpdateDto.Post);
    }

    public async Task<bool> DeletePostAsync(int postId)
    {
        Post? postToBeDeleted = await _postDao.GetPostByIdAsync(postId);
        return await _postDao.DeletePostAsync(postToBeDeleted);
    }

    public async Task<Post?> GetPostByIdAsync(int postId)
    {
        return await _postDao.GetPostByIdAsync(postId);
    }

    public async Task<IEnumerable<Post>?> GetPostsByUser(string userName)
    {
        return await _postDao.GetPostsByUser(userName);
    }

    public static void ValidateData(PostUpdateDto postDto)
    {
        string title = postDto.Post.Title;
        string context = postDto.Post.Context;


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