using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Services;

public interface IMusicService
{
    Task<long> AddMusicAsync(MusicDto musicDto);
    Task<List<MusicDto>> GetAllMusicAsync();
    Task DeleteMusicAsync(long id);
    Task UpdateMusicAsync(MusicDto musicDto);
    Task<MusicDto> GetMusicByIdAsync(long id);
    Task<List<MusicDto>> GetAllMusicByAuthorNameAsync(string name);
    Task<MusicDto> GetMostLikedMusicAsync();
    Task<MusicDto> GetMusicByNameAsync(string name);
    Task<List<MusicDto>> GetAllMusicAboveSizeAsync(double minSize);
    Task<List<MusicDto>> GetAllMusicBelowSizeAsync(double minSize);
    Task<List<MusicDto>> GetTopMostLikedMusicAsync(int count);
    Task<List<MusicDto>> GetTheLessLikedMusicAsync(int count);
    Task<List<MusicDto>> GetMusicByDescriptionKeywordAsync(string keyword);
    Task<List<MusicDto>> GetMusicWithLikesInRangeAsync(int minLikes, int maxLikes);
    Task<List<string>> GetAllUniqueAuthorsAsync();
    Task<double> GetTotalMusicSizeByAuthorAsync(string authorName);
}