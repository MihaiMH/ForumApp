using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext _context;

    public PostFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Post> CreatePostAsync(Post post)
    {
        int postId = 1;

        if (_context.Posts != null && _context.Posts.Any())
        {
            postId = _context.Posts.Max(u => u.Id);
            postId++;
        }

        post.Id = postId;
        _context.Posts?.Add(post);
        _context.SaveChanges();
        return Task.FromResult(post);
    }
}