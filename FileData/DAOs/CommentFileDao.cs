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
}