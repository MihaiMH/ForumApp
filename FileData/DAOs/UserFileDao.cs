using Application.DaoInterfaces;
using Domain;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext _context;

    public UserFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        _context.Users?.Add(user);
        _context.SaveChanges();
        Console.WriteLine("UserFileDaoContextUsers" + _context.Users +"SSSS");
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        ICollection<User>? users =  _context.Users;

        User? user =  users?.FirstOrDefault(e => e.Username.Equals(username));

        return Task.FromResult(user);

    }

    public Task<IEnumerable<User>?> GetUsersByUsernameAsync(string username)
    {
        ICollection<User>? users = _context.Users;
        IEnumerable<User>? foundUsers = users?.Where(e => e.Username.Equals(username));
        return Task.FromResult(foundUsers);
    }
}