using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class CommentFileDao : ICommentDao
{
    private readonly FileContext _context;

    public CommentFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Comment> CreateCommentAsync(Comment comment)
    {
        int commentId = 1;

        if (_context.Comments != null && _context.Comments.Any())
        {
            commentId = _context.Comments.Max(u => u.Id);
            commentId++;
        }

        comment.Id = commentId;
        _context.Comments?.Add(comment);
        _context.SaveChanges();
        return Task.FromResult(comment);
    }

    public Task<IEnumerable<Comment>?> GetCommentsByPost(int postId)
    {
        ICollection<Comment>? comments = _context.Comments;
        IEnumerable<Comment>? foundComments = comments?.Where(e => e.Post.Id == postId);
        return Task.FromResult(foundComments);
    }

    public Task<Comment?> GetCommentById(int commentId)
    {
        Comment? comment = _context.Comments?.FirstOrDefault(e => e.Id == commentId);
        return Task.FromResult(comment);
    }

    public Task<Comment> UpdateComment(int oldCommentId, String newContext)
    {
        if (_context.Comments != null && _context.Comments.Any())
        {
            Comment? comment = _context.Comments?.FirstOrDefault(e => e.Id == oldCommentId);
            if (comment != null)
            {
                comment.Context = newContext;
                _context.SaveChanges();
                return Task.FromResult(comment);
            }
        }

        return Task.FromResult(new Comment(null,"NOT FOUND", null));
    }

    public Task<bool> DeleteComment(int commentId)
    {
        Comment? comment = _context.Comments?.FirstOrDefault(e => e.Id == commentId);
        if (comment != null)
        {
            _context.Comments?.Remove(comment);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}