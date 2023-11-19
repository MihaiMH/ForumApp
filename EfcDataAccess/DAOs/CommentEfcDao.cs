using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly AppDbContext context;

    public CommentEfcDao(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Comment> CreateCommentAsync(Comment comment)
    {
        EntityEntry<Comment> createdComment = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return createdComment.Entity;
    }

    public async Task<IEnumerable<Comment>?> GetCommentsByPost(int postId)
    {
        IEnumerable<Comment>? comments = context.Comments.Include(u=>u.Post).Include(u=>u.User).Where(c => c.Post.Id == postId);
        return comments;
    }

    public async Task<Comment?> GetCommentById(int commentId)
    {
        Comment? comment = await context.Comments.Include(u=>u.Post).Include(u=>u.User).FirstOrDefaultAsync(c => c.Id == commentId);
        return comment;
    }

    public async Task<Comment> UpdateComment(Comment comment)
    {
        if (comment != null)
        {
            EntityEntry<Comment> newComment = context.Comments.Update(comment);
            await context.SaveChangesAsync();
            return newComment.Entity;
        }

        return null;
    }

    public async Task<bool> DeleteComment(Comment comment)
    {
        if (comment != null)
        {
            context.Comments.Remove(comment);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}