namespace Domain.DTOs;

public class SubforumDto
{
    public int Id { get; }
    public string Title { get; }
    public string Owner { get; }

    public SubforumDto(int id, string title, string owner)
    {
        Id = id;
        Title = title;
        Owner = owner;
    }
}