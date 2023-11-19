using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    [Key]
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public ICollection<Subforum> Subforums { get; set; }
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
    [JsonIgnore]
    public ICollection<Comment> Comments { get; set; }

    public User()
    {
    }
}