using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain;
using Domain.DTOs;

namespace BlazorWasm.Services;

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();

    // this private variable for simple caching
    public static string? Jwt { get; private set; } = "";

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null;

    public async Task LoginAsync(string username, string password)
    {
        LogInDto userLoginDto = new(username, password);

        string userAsJson = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7133/Auth/login", userLoginDto);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        
        
        string token = responseContent;
        Console.WriteLine(token);
        Jwt = token;
        
        ClaimsPrincipal principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);

        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged.Invoke(principal);
        return Task.CompletedTask;
    }

    public Task RegisterAsync(User user)
    {
        throw new NotImplementedException();
        // string userAsJson = JsonSerializer.Serialize(user);
        // StringContent content = new(userAsJson, Encoding.UTF8, "application/json");
        // HttpResponseMessage response = await client.PostAsync("https://localhost:7130/auth/register", content);
        // string responseContent = await response.Content.ReadAsStringAsync();
        //
        // if (!response.IsSuccessStatusCode)
        // {
        //     throw new Exception(responseContent);
        // }
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }
}