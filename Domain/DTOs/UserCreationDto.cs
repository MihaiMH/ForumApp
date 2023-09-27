namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }

    public UserCreationDto(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}