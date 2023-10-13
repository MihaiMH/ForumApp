namespace Domain.DTOs;

public class CommentDto
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Context { get; set; }
    public int PostId { get; set; }

    public CommentDto(string user, string context, int postId)
    {
        User = user;
        Context = context;
        PostId = postId;
    }
}