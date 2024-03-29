using System.Collections;
using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Post>> GetPostsBySubforumAsync(string subForumId)
    {
        string uri = "/GetPostsBySubForum";
        if (!string.IsNullOrEmpty(subForumId))
        {
            uri += $"?subForumId={subForumId}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine(result);
        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> GetPostById(string postId)
    {
        string uri = "/GetPostById";
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
        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<IEnumerable<Post>> GetPostsByUserAsync(string userName)
    {
        string uri = "/GetPostsByUser";
        if (!string.IsNullOrEmpty(userName))
        {
            uri += $"?userName={userName}";
        }

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Console.WriteLine(result);
        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> CreatePostAsync(int subforumId, string title, string context, User user)
    {
        PostDto postDto = new PostDto(-1, subforumId, title, context, user);
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", postDto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}