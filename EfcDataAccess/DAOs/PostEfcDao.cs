using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly AppDbContext context;

    public PostEfcDao(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<Post> CreatePostAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>?> GetPostsBySubForumAsync(int subForumId)
    {
        IEnumerable<Post>? existing = context.Posts.Include(u=>u.Subforum).Include(u=>u.Author).Where(p =>
            p.Subforum.Id == subForumId
        );
        return existing;
    }

    public async Task<Post> UpdatePostAsync(Post post)
    {
        EntityEntry<Post> updatedPost = context.Posts.Update(post);
        await context.SaveChangesAsync();
        return updatedPost.Entity;
    }

    public async Task<bool> DeletePostAsync(Post post)
    {
        if (post != null)
        {
            EntityEntry<Post> deletedPost = context.Posts.Remove(post);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Post?> GetPostByIdAsync(int postId)
    {
        Post? post = await context.Posts.Include(u=>u.Subforum).Include(u=>u.Author).FirstOrDefaultAsync(p => p.Id == postId);
        return post;
    }

    public async Task<IEnumerable<Post>?> GetPostsByUser(string userName)
    {
        IEnumerable<Post> posts = context.Posts.Include(u=>u.Subforum).Include(u=>u.Author).Where(p => p.Author.Username.Equals(userName));
        return posts;
    }
}