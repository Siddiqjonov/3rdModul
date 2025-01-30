using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Repository.Services;
using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Services;

namespace MusicCRUD.Server.Controllers
{
    [Route("api/music")]
    [ApiController]

    public class MusicController : ControllerBase
    {
        private IMusicService _musicService;
        public MusicController()
        {
            _musicService = new MusicService();
        }
        [HttpPost("addMusic")]
        public Guid AddMusic(MusicDto musicDto)
        {
            var musicId = _musicService.AddMusic(musicDto);
            return musicId;
        }
        [HttpGet("getAllMusic")]
        public List<MusicDto> GetAllMusigc()
        {
            var musicList = _musicService.GetAllMusic();
            return musicList;
        }
        [HttpDelete("deleteMusic/{id}")]
        public void DeleteMusic(Guid id)
        {
            _musicService.DeleteMusic(id);
        }
        [HttpPut("updateMusic")]
        public void UpdateMusic(MusicDto musicDto)
        {
            _musicService.UpdateMusic(musicDto);
        }
        [HttpGet("getMusicById")]
        public MusicDto GetMusicById(Guid id)
        {
            var musicList = _musicService.GetMusicById(id);
            return musicList;
        }
        [HttpGet("getAllMusicByAuthorName/{name}")]
        public List<MusicDto> GetAllMusicByAuthorName(string name)
        {
            var musicList = _musicService.GetAllMusicByAuthorName(name);
            return musicList;
        }
        [HttpGet("getMostLikedMusic")]
        public MusicDto GetMostLikedMusic()
        {
            var musicList = _musicService.GetMostLikedMusic();
            return musicList;
        }
        [HttpGet("getMusicByName")]
        public MusicDto GetMusicByName(string name)
        {
            var music = _musicService.GetMusicByName(name);
            return music;
        }
        [HttpGet("getAllMusicAboveSize")]
        public List<MusicDto> GetAllMusicAboveSize(double minSize)
        {
            var musicList = _musicService.GetAllMusicAboveSize(minSize);
            return musicList;
        }
        [HttpGet("getAllMusicBelowSize")]
        public List<MusicDto> GetAllMusicBelowSize(double minSize)
        {
            var musicList = _musicService.GetAllMusicBelowSize(minSize);
            return musicList;
        }
        [HttpGet("getTopMostLikedMusic")]
        public List<MusicDto> GetTopMostLikedMusic(int count)
        {
            var musicList = _musicService.GetTopMostLikedMusic(count);
            return musicList;
        }
        [HttpGet("getTheLessLikedMusic")]
        public List<MusicDto> GetTheLessLikedMusic(int count)
        {
            var musicList = _musicService.GetTheLessLikedMusic(count);
            return musicList;
        }
        [HttpGet("getMusicByDescriptionKeyword")]
        public List<MusicDto> GetMusicByDescriptionKeyword(string keyword)
        {
            var musicList = _musicService.GetMusicByDescriptionKeyword(keyword);
            return musicList;
        }
        [HttpGet("getMusicWithLikesInRange")]
        public List<MusicDto> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            var musicList = _musicService.GetMusicWithLikesInRange(minLikes, maxLikes);
            return musicList;
        }
        [HttpGet("getAllUniqueAuthors")]
        public List<string> GetAllUniqueAuthors()
        {
            var names = _musicService.GetAllUniqueAuthors();
            return names;
        }
        [HttpGet("getTotalMusicSizeByAuthor")]
        public double GetTotalMusicSizeByAuthor(string authorName)
        {
            var totalMB = _musicService.GetTotalMusicSizeByAuthor(authorName);
            return totalMB;
        }
    }
}
