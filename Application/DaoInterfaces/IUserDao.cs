using Domain;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>?> GetUsersByUsernameAsync(String username);
    Task<IEnumerable<User>?> GetAllUsers();
}