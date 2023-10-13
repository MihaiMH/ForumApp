using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class SubforumHttpClient : ISubforumService
{
    private readonly HttpClient client;

    public SubforumHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<IEnumerable<Subforum>> GetSubforumsAsync(string? subForums = null)
    {
        HttpResponseMessage response = await client.GetAsync("/Subforum");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        IEnumerable<Subforum> subforums = JsonSerializer.Deserialize<IEnumerable<Subforum>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return subforums;
    }

    public async Task<Subforum> CreateSubForumAsync(string title, string user)
    {
        SubforumDto subforumDto = new SubforumDto(-1, title, user);
        HttpResponseMessage response = await client.PostAsJsonAsync("/Subforum", subforumDto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        Subforum subforum = JsonSerializer.Deserialize<Subforum>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return subforum;
    }
}