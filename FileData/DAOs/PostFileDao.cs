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


    public Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId)
    {
        ICollection<Post>? posts = _context.Posts;
        IEnumerable<Post>? found = posts?.Where(e => e.Subforum.Id == subForumId);
        return Task.FromResult(found);
    }

    public Task<Post> UpdatePostAsync(int postId, string title, string context)
    {
        Post? post = _context.Posts?.FirstOrDefault(e => e.Id == postId);
        if (post != null)
        {
            post.Title = title;
            post.Context = context;
            _context.SaveChanges();
            return Task.FromResult(post);
        }

        return Task.FromResult(new Post("NOT FOUND", null, "NOT FOUND", null));
    }

    public Task<bool> DeletePostAsync(int postId)
    {
        Post? post = _context.Posts?.FirstOrDefault(e => e.Id ==postId);
        if (post != null)
        {
            _context.Posts?.Remove(post);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}