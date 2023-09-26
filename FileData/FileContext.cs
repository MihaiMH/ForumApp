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
                Posts = new List<Post>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        Console.WriteLine("FileContextUsers" + Users + "SSSSSS");
        Console.WriteLine("FileContextDataContainerUsers " + dataContainer  + "SSSSSSS" );
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}