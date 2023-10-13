using Domain;

namespace HttpClients.ClientInterfaces;

public interface ISubforumService
{
    Task<IEnumerable<Subforum>> GetSubforumsAsync(string? subForums = null);
    Task<Subforum> CreateSubForumAsync(string title, string user);
}