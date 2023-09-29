namespace Domain.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Context { get; set; }
    public Post Post { get; set; }

    public CommentDto(User user, string context, Post post)
    {
        User = user;
        Context = context;
        Post = post;
    }
}