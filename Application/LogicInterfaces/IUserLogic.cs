using System.Collections;
using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userCreationDto);
    Task<User> Login(LogInDto logInDto);
    Task<User?> GetByUsernameAsync(string username);
    Task<IEnumerable<User>?> GetAllUsers();
}