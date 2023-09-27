namespace Domain;

public class Subforum
{
    public int Id { get; set; }
    public string Title { get; set; }
    public User Owner { get; set; }

    public Subforum(string title, User owner)
    {
        Title = title;
        Owner = owner;
    }
}