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
    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }
    // DONE
    public Guid AddMusic(MusicDto musicDto)
    {
        return _musicRepository.Add(ConvertToMusicEntity(musicDto));
    }
    // DONE
    public void DeleteMusic(Guid id)
    {
        _musicRepository.Delete(id);
    }
    // DONE
    public List<MusicDto> GetAllMusic()
    {
        //var musicList = _musicRepository.GetAll();
        //List<MusicDto> music = musicList.Select(mus => ConvertToMusicDto(mus)).ToList();
        //return music;

        return _musicRepository.GetAll().Select(muz => ConvertToMusicDto(muz)).ToList();
    }
    // DONE
    public List<MusicDto> GetAllMusicAboveSize(double minSize)
    {
        return GetAllMusic().Where(mus => mus.MB > minSize).ToList();
    }
    // DONE
    public List<MusicDto> GetAllMusicBelowSize(double minSize)
    {
        return GetAllMusic().Where(mus => mus.MB < minSize).ToList();
    }
    // DONE
    public List<MusicDto> GetAllMusicByAuthorName(string name)
    {
        return GetAllMusic().Where(mus => mus.AuthorName.ToLower().Equals(name.ToLower())).ToList();
    }
    // DONE
    public List<string> GetAllUniqueAuthors()
    {

        return GetAllMusic().Where(mus => GetAllMusic().Count(muz => mus.AuthorName.Equals(muz.AuthorName)) == 1).Select(mz => mz.AuthorName).ToList();
        //var music = GetAllMusic();
        //var names = new List<string>();
        //foreach (MusicDto mus in music)
        //{
        //    var count = music.Count(muz => mus.AuthorName.Equals(muz.AuthorName));
        //    if (count == 1)
        //        names.Add(mus.AuthorName);
        //}
        //return names;
    }
    // DONE
    public MusicDto GetMostLikedMusic()
    {
        //int mostLiked = GetAllMusic().Max(mus => mus.QuentityLikes);
        //return GetAllMusic().FirstOrDefault(muz => muz.QuentityLikes == mostLiked) ?? throw new NullReferenceException("Storage is empty"); 

        return GetAllMusic().OrderByDescending(mus => mus.QuentityLikes).FirstOrDefault() ?? throw new NullReferenceException("Storage is empty");
    }
    // DONE
    public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
    {
        return GetAllMusic().Where(mus => mus.Description.ToLower().Contains(keyword.ToLower())).ToList();
    }
    // DONE
    public MusicDto GetMusicById(Guid id)
    {
        return ConvertToMusicDto(_musicRepository.GetById(id));
    }
    // DONE
    public MusicDto GetMusicByName(string name)
    {
        return GetAllMusic().FirstOrDefault(mus => mus.Name.ToLower().Equals(name.ToLower())) ?? throw new NullReferenceException("Storage is empty");
    }
    // DONE
    public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
    {
        return GetAllMusic().Where(muz => muz.QuentityLikes >= minLikes && muz.QuentityLikes <= maxLikes).ToList();
    }
    // DONE
    public List<MusicDto> GetTheLessLikedMusic(int count)
    {
        return GetAllMusic().OrderByDescending(mus => mus.QuentityLikes).ThenBy(muz => muz.Name).TakeLast(count).ToList();
    }
    // DONE
    public List<MusicDto> GetTopMostLikedMusic(int count)
    {
        return GetAllMusic().OrderByDescending(mus => mus.QuentityLikes).ThenBy(muz => muz.Name).Take(count).ToList();
    }
    // DONE
    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        return GetAllMusic().Where(music => music.AuthorName.ToLower().Equals(authorName.ToLower())).Sum(mz => mz.MB);
        // return GetAllMusic().Where(mus => mus.AuthorName.ToLower() == authorName.ToLower()).Sum(muz => muz.MB);

    }
    // DONE
    public void UpdateMusic(MusicDto musicDto)
    {
        _musicRepository.Update(ConvertToMusicEntity(musicDto));
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
