using MusicCRUD.DataAccess.Entity;
using MusicCRUD.Repository.Services;
using MusicCRUD.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Service.Services;

public class MusicService : IMusicService
{
    private IMusicRepository _musicRepository;

    public MusicService(IMusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }

    // DONE
    public async Task<Guid> AddMusicAsync(MusicDto musicDto)
    {
        var music = ConvertToMusicEntity(musicDto);
        Guid id = await _musicRepository.AddAsync(music);
        return id;
    }
    // DONE
    public async Task DeleteMusicAsync(Guid id)
    {
        await _musicRepository.DeleteAsync(id);
    }
    // DONE
    public async Task<List<MusicDto>> GetAllMusicAsync()
    {
        //var musicList = _musicRepository.GetAll();
        //List<MusicDto> music = musicList.Select(mus => ConvertToMusicDto(mus)).ToList();
        //return music;

        var all = await _musicRepository.GetAllAsync();
        return all.Select(muz => ConvertToMusicDto(muz)).ToList();
    }
    // DONE
    public async Task<List<MusicDto>> GetAllMusicAboveSizeAsync(double minSize)
    {
        var all = await GetAllMusicAsync();
        return all.Where(mus => mus.MB > minSize).ToList();
    }
    // DONE
    public async Task<List<MusicDto>> GetAllMusicBelowSizeAsync(double minSize)
    {
        var all = await GetAllMusicAsync();
        return all.Where(mus => mus.MB < minSize).ToList();
    }
    // DONE
    public async Task<List<MusicDto>> GetAllMusicByAuthorNameAsync(string name)
    {
        var all = await GetAllMusicAsync(); 
        return all.Where(mus => mus.AuthorName.ToLower().Equals(name.ToLower())).ToList();
    }
    // DONE
    public async Task<List<string>> GetAllUniqueAuthorsAsync()
    {

        //return GetAllMusicAsync().Result.Where(mus => GetAllMusicAsync().Result.Count(muz => mus.AuthorName.Equals(muz.AuthorName)) == 1).Select(mz => mz.AuthorName).ToList();
        var music = await GetAllMusicAsync();
        var names = new List<string>();
        foreach (MusicDto mus in music)
        {
            var count = music.Count(muz => mus.AuthorName.Equals(muz.AuthorName));
            if (count == 1)
                names.Add(mus.AuthorName);
        }
        return names;
    }
    // DONE
    public async Task<MusicDto> GetMostLikedMusicAsync()
    {
        //int mostLiked = GetAllMusic().Max(mus => mus.QuentityLikes);
        //return GetAllMusic().FirstOrDefault(muz => muz.QuentityLikes == mostLiked) ?? throw new NullReferenceException("Storage is empty"); 

        var all = await GetAllMusicAsync();
        return all.OrderByDescending(mus => mus.QuentityLikes).FirstOrDefault() ?? throw new NullReferenceException("Storage is empty");
    }
    // DONE
    public async Task<List<MusicDto>> GetMusicByDescriptionKeywordAsync(string keyword)
    {
        var all = await GetAllMusicAsync();
        return all.Where(mus => mus.Description.ToLower().Contains(keyword.ToLower())).ToList();
    }
    // DONE
    public async Task<MusicDto> GetMusicByIdAsync(Guid id)
    {
        var music = await _musicRepository.GetByIdAsync(id);
        return ConvertToMusicDto(music);
    }
    // DONE
    public async Task<MusicDto> GetMusicByNameAsync(string name)
    {
        var all = await GetAllMusicAsync();
        return all.FirstOrDefault(mus => mus.Name.ToLower().Equals(name.ToLower())) ?? throw new NullReferenceException("Storage is empty");
    }
    // DONE
    public async Task<List<MusicDto>> GetMusicWithLikesInRangeAsync(int minLikes, int maxLikes)
    {
        var all = await GetAllMusicAsync();
        return all.Where(muz => muz.QuentityLikes >= minLikes && muz.QuentityLikes <= maxLikes).ToList();
    }
    // DONE
    public async Task<List<MusicDto>> GetTheLessLikedMusicAsync(int count)
    {
        var all = await GetAllMusicAsync();
        return all.OrderByDescending(mus => mus.QuentityLikes).ThenBy(muz => muz.Name).TakeLast(count).ToList();
    }
    // DONE
    public async Task<List<MusicDto>> GetTopMostLikedMusicAsync(int count)
    {
        var all = await GetAllMusicAsync();
        return all.OrderByDescending(mus => mus.QuentityLikes).ThenBy(muz => muz.Name).Take(count).ToList();
    }
    // DONE
    public async Task<double> GetTotalMusicSizeByAuthorAsync(string authorName)
    {
        var all = await GetAllMusicAsync();
        return all.Where(music => music.AuthorName.ToLower().Equals(authorName.ToLower())).Sum(mz => mz.MB);
        // return GetAllMusic().Where(mus => mus.AuthorName.ToLower() == authorName.ToLower()).Sum(muz => muz.MB);

    }
    // DONE
    public async Task UpdateMusicAsync(MusicDto musicDto)
    {
        await _musicRepository.UpdateAsync(ConvertToMusicEntity(musicDto));
    }

    private static Music ConvertToMusicEntity(MusicDto musicDto)
    {
        return new Music()
        {
            Id = musicDto.Id ?? Guid.NewGuid(),
            AuthorName = musicDto.AuthorName,
            Description = musicDto.Description,
            MB = musicDto.MB,
            Name = musicDto.Name,
            QuentityLikes = musicDto.QuentityLikes,
        };
    }
    private static MusicDto ConvertToMusicDto(Music music)
    {
        return new MusicDto()
        {
            Id = music.Id,
            AuthorName = music.AuthorName,
            Description = music.Description,
            MB = music.MB,
            Name = music.Name,
            QuentityLikes = music.QuentityLikes
        };
    }
}
