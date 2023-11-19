using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain;

public class Subforum
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public User Owner { get; set; }

    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }

    public Subforum()
    {
    }
    
    
}