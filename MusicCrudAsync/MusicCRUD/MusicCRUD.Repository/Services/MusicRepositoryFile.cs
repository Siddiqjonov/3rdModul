using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicCRUD.Repository.Services;

public class MusicRepositoryFile : IMusicRepository
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly List<Music> _music;
    public MusicRepositoryFile()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Music.json"); // "/" "\" 
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
        _music = GetAllAsync().Result;
    }
    public async Task<long> AddAsync(Music music)
    {
        _music.Add(music);
        SaveData();
        return music.MusicId;
    }

    public async Task DeleteAsync(long id)
    {
        //var musicFromDb = GetById(id);
        //_music.Remove(musicFromDb);
        
        _music.Remove(GetByIdAsync(id).Result);
        SaveData();
    }

    public async Task<List<Music>> GetAllAsync()
    {
        return JsonSerializer.Deserialize<List<Music>>(File.ReadAllText(_filePath)) ?? throw new NullReferenceException();

        //var musicJson = File.ReadAllText(_filePath);
        //var musicList = JsonSerializer.Deserialize<List<Music>>(musicJson);
        //return musicList ?? throw new NullReferenceException();
    }

    public async Task<Music> GetByIdAsync(long id)
    {
        return _music.FirstOrDefault(ms => ms.MusicId == id) ?? throw new NullReferenceException();

        //var music =  _music.FirstOrDefault(muz => muz.Id == id);
        //return music ?? throw new NullReferenceException();
    }

    public async Task UpdateAsync(Music music)
    {
        //var musicFromDb = GetById(music.Id);
        //var index = _music.IndexOf(musicFromDb);
        //_music[index] = music;

        _music[_music.IndexOf(GetByIdAsync(music.MusicId).Result)] = music;
        SaveData();
    }
    private void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_music);
        File.WriteAllText(_filePath, musicJson);
    }
}
