using Domain;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<Subforum> Subforums { get; set; }
}