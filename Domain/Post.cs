using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.DTOs;

namespace Domain;

public class Post
{
    [Key]
    public int Id { get; set; }
    public Subforum Subforum { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public User Author { get; set; }

    [JsonIgnore]
    public ICollection<Comment> Comments { get; set; }

    public Post()
    {
    }


}