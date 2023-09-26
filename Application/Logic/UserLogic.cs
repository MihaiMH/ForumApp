using System.Net.Mail;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao _userDao;

    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userCreationDto)
    {
        User? existing = await _userDao.GetByUsernameAsync(userCreationDto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(userCreationDto);
        User toCreate = new User(userCreationDto.Username, userCreationDto.Email, userCreationDto.Password);

        User created = await _userDao.CreateAsync(toCreate);
        Console.WriteLine("UserLogic" + toCreate + "SSSS");
        return created;
    }

    public async Task<User> Login(LogInDto logInDto)
    {
        IEnumerable<User>? users = await _userDao.GetUsersByUsernameAsync(logInDto.Username);
        if (users != null)
        {
            foreach (var user in users)
            {
                if (user.Password.Equals(logInDto.Password))
                {
                    return user;
                }
            }

            return null;
        }

        return null;
    }


    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;
        string password = userToCreate.Password;
        string email = userToCreate.Email;

        if (userName.Length < 5)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 18)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 6 || string.IsNullOrWhiteSpace(password))
            throw new Exception("Password must be longer than 6 characters");
        if (password.Length > 20)
            throw new Exception("Password must be shorter than 20 characters");
        try
        {
            MailAddress m = new MailAddress(email);
        }
        catch (Exception e)
        {
            throw new Exception("Invalid email format");
        }
    }
}