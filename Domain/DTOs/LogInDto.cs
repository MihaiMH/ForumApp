namespace Domain.DTOs;

public class LogInDto
{
    public string Username { get;  }
    public string Password { get;  }

    public LogInDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}