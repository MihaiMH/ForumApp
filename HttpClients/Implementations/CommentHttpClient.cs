using System.Text.Json;
using Domain;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class CommentHttpClient : ICommentService
{
    private readonly HttpClient client;

    public CommentHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(string postId)
    {
        string uri = "/Comment";
        if (!string.IsNullOrEmpty(postId))
        {
            uri += $"?postId={postId}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine(result);
        IEnumerable<Comment> comments = JsonSerializer.Deserialize<IEnumerable<Comment>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comments;
    }
}