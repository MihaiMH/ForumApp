using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateUser(UserCreationDto dto);
    
}