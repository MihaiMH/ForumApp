namespace Domain.DTOs;

public class PostUpdateDto
{
    public Post Post { get; set; }

    public PostUpdateDto(Post post)
    {
        this.Post = post;
    }
}