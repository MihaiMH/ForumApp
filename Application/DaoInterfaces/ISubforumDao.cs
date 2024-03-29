using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface ISubforumDao
{
    Task<Subforum> CreateAsync(Subforum subforumDto);
    Task<Subforum?> GetByTitleAsync(string title);
    Task<IEnumerable<Subforum>?> GetSubForums();

    Task<Subforum?> GetByIdAsync(int id);
}