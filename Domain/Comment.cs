using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Comment
{
    [Key]
    public int Id { get; set; }
    public User User { get; set; }
    public string Context { get; set; }
    public Post Post { get; set; }

    public Comment()
    {
    }

}