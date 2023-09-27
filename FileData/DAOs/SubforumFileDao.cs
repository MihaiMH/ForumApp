using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class SubforumFileDao : ISubforumDao
{
    private readonly FileContext _context;

    public SubforumFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Subforum> CreateAsync(Subforum subforum)
    {
        int subforumId = 1;

        if (_context.Subforums != null && _context.Subforums.Any())
        {
            subforumId = _context.Subforums.Max(u => u.Id);
            subforumId++;
        }

        subforum.Id = subforumId;

        _context.Subforums?.Add(subforum);
        _context.SaveChanges();
        return Task.FromResult(subforum);
    }

    public Task<Subforum?> GetByTitleAsync(string title)
    {
        ICollection<Subforum>? subforums = _context.Subforums;
        Subforum? subforum = subforums?.FirstOrDefault(e => e.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(subforum);
    }
}