using Application.DaoInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class SubForumEfcDao : ISubforumDao
{
    private readonly AppDbContext context;

    public SubForumEfcDao(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Subforum> CreateAsync(Subforum subforum)
    {
        EntityEntry<Subforum> createdSubforum = await context.Subforums.AddAsync(subforum);
        await context.SaveChangesAsync();
        return createdSubforum.Entity;
    }

    public async Task<Subforum?> GetByTitleAsync(string title)
    {
        Subforum? found = await context.Subforums.Include(u=>u.Owner).FirstOrDefaultAsync(s => s.Title.Equals(title));
        return found;
    }

    public async Task<IEnumerable<Subforum>?> GetSubForums()
    {
        try
        {
            IQueryable<Subforum> query = context.Subforums.Include(u=>u.Owner).AsQueryable();
            IEnumerable<Subforum> subforums = await query.ToListAsync();
            Console.WriteLine(subforums);
            foreach (var VARIABLE in subforums)
            {
                Console.WriteLine(VARIABLE.Owner);
                Console.WriteLine(VARIABLE.Owner.Username);
            }

            return subforums;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception(e.Message);
        }
    }

    public async Task<Subforum?> GetByIdAsync(int id)
    {
        Subforum? found = await context.Subforums.Include(u=>u.Owner).FirstOrDefaultAsync(s => s.Id == id);
        return found;
    }
}