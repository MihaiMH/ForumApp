namespace Domain.DTOs;

public class SubforumDto
{
    public int Id { get; }
    public string Title { get; }
    public User Owner { get; }

    public SubforumDto(int id, string title, User owner)
    {
        Id = id;
        Title = title;
        Owner = owner;
    }
}