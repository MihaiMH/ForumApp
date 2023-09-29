namespace Domain;

public class Comment
{
    public int Id { get; set; }
    public User User { get; set; }
    public string Context { get; set; }
    public Post Post { get; set; }

    public Comment(User user, string context, Post post)
    {
        this.User = user;
        this.Context = context;
        this.Post = post;
    }

}