using System.ComponentModel.DataAnnotations;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserLogic userLogic;

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userLogic.GetByUsernameAsync(username);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return await Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        // Do more user info validation here

        // save to persistence instead of list

        userLogic.CreateAsync(new UserCreationDto(user.Username, user.Email, user.Password));

        return Task.CompletedTask;
    }
}