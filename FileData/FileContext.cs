using System.Text.Json;
using Domain;
using FileData.DAOs;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";

    private DataContainer? dataContainer;

    public ICollection<User>? Users
    {
        get
        {
            LazyLoadData();
            return dataContainer?.Users;
        }
    }

    public ICollection<Post>? Posts
    {
        get
        {
            LazyLoadData();
            return dataContainer?.Posts;
        }
    }

    public ICollection<Subforum>? Subforums
    {
        get
        {
            LazyLoadData();
            return dataContainer?.Subforums;
        }
    }
    
    public ICollection<Comment>? Comments
    {
        get
        {
            LazyLoadData();
            return dataContainer?.Comments;
        }
    }

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Users = new List<User>(),
                Posts = new List<Post>(),
                Subforums = new List<Subforum>(),
                Comments = new List<Comment>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}