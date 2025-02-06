using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientPractice;

public class MusicCrudApiBroker
{
    private string _baseUrl;
    private HttpClient _httpClient;
    public MusicCrudApiBroker()
    {
        _baseUrl = "https://localhost:7158/api/music/";
        _httpClient = new HttpClient();
        //Add();
        //GetAll();
        //Delete();
        //Update();
        GetMusicByAuthorName();
    }
    public void GetAll()
    {
        string url = $"{_baseUrl}getAllMusic";

        var responseMessage = _httpClient.GetAsync(url).Result;
        responseMessage.EnsureSuccessStatusCode();
        var responseContent = responseMessage.Content;
        string content = responseContent.ReadAsStringAsync().Result;

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive= true;

        var music = JsonSerializer.Deserialize<Music[]>(content, options);
        foreach (var m in music)
        {
            Console.WriteLine(m);
        }
    }
    public void Add()
    {
        string url = $"{_baseUrl}addMusic";

        var music = new Music()
        {
            Name = "HelloWorld",
            AuthorName = "Anonim",
            Description = "Nice",
            MB = 6.4,
            QuentityLikes = 8999
        };
        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var responseMessage = _httpClient.PostAsync(url, content).Result;
        responseMessage.EnsureSuccessStatusCode();

        var id = responseMessage.Content.ReadAsStringAsync().Result;
        Console.WriteLine(id);
    }
    public void Delete()
    {
        var id = new Guid("b5edeba2-1d16-4c8f-a51e-a698bf0ecb32");
        string url = $"{_baseUrl}deleteMusic/{id}";
        var responseMessage = _httpClient.DeleteAsync(url).Result;

        responseMessage.EnsureSuccessStatusCode();

        var returnContent = responseMessage.Content.ReadAsStringAsync().Result;
        Console.WriteLine(returnContent);

    }
    public void Update()
    {
        string url = $"{_baseUrl}updateMusic";
        var music = new Music()
        {
            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            AuthorName = "Anton",
            Description = "BAD",
            MB = 43.4,
            Name = "Just give up",
            QuentityLikes = 43
        };
        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var responseMessage = _httpClient.PutAsync(url, content).Result;
        responseMessage.EnsureSuccessStatusCode();
    }
    public void GetMusicByAuthorName()
    {
        string name = "Anton";
        string url = $"{_baseUrl}getAllMusicByAuthorName/{name}";

        var responseMessage = _httpClient.GetAsync(url).Result;
        responseMessage.EnsureSuccessStatusCode();

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;
        var content = responseMessage.Content.ReadAsStringAsync().Result;
        var music = JsonSerializer.Deserialize<Music[]>(content, options);

        foreach (var m in music)
        {
            Console.WriteLine(m);
        }

    }
}
