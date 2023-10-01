namespace Domain.DTOs;

public class UpdateCommentDto
{
    public int OldCommentId { get; set; }
    public string NewContext { get; set; }
    public int PostId { get; set; }

    public UpdateCommentDto(int oldCommentId, string newContext, int postId)
    {
        OldCommentId = oldCommentId;
        NewContext = newContext;
        PostId = postId;
    }
}