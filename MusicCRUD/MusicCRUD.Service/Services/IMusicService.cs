using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Services;

public interface IMusicService
{
    Guid AddMusic(MusicDto musicDto);
    List<MusicDto> GetAllMusic();
    void DeleteMusic(Guid id);
    void UpdateMusic(MusicDto musicDto);
    MusicDto GetMusicById(Guid id);
    List<MusicDto> GetAllMusicByAuthorName(string name);
    MusicDto GetMostLikedMusic();
    MusicDto GetMusicByName(string name);
    List<MusicDto> GetAllMusicAboveSize(double minSize);
    List<MusicDto> GetAllMusicBelowSize(double minSize);
    List<MusicDto> GetTopMostLikedMusic(int count);
    List<MusicDto> GetTheLessLikedMusic(int count);
    List<MusicDto> GetMusicByDescriptionKeyword(string keyword);
    List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}