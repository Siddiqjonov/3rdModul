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
        public async Task<Guid> AddMusic(MusicDto musicDto)
        {
            var musicId = await _musicService.AddMusicAsync(musicDto);
            return musicId;
        }
        [HttpGet("getAllMusic")]
        public async Task<List<MusicDto>> GetAllMusigc()
        {
            var musicList = await _musicService.GetAllMusicAsync();
            return musicList;
        }
        [HttpDelete("deleteMusic")]
        public async void DeleteMusic(Guid id)
        {
            await _musicService.DeleteMusicAsync(id);
        }
        [HttpPut("updateMusic")]
        public async void Task<UpdateMusic>(MusicDto musicDto)
        {
            await _musicService.UpdateMusicAsync(musicDto);
        }
        [HttpGet("getMusicById")]
        public async Task<MusicDto> GetMusicById(Guid id)
        {
            var musicList = await _musicService.GetMusicByIdAsync(id);
            return musicList;
        }
        [HttpGet("getAllMusicByAuthorName")]
        public async Task<List<MusicDto>> GetAllMusicByAuthorName(string name)
        {
            var musicList = await _musicService.GetAllMusicByAuthorNameAsync(name);
            return musicList;
        }
        [HttpGet("getMostLikedMusic")]
        public async Task<MusicDto> GetMostLikedMusic()
        {
            var musicList = await _musicService.GetMostLikedMusicAsync();
            return musicList;
        }
        [HttpGet("getMusicByName")]
        public async Task<MusicDto> GetMusicByName(string name)
        {
            var music = await _musicService.GetMusicByNameAsync(name);
            return music;
        }
        [HttpGet("getAllMusicAboveSize")]
        public async Task<List<MusicDto>> GetAllMusicAboveSize(double minSize)
        {
            var musicList = await _musicService.GetAllMusicAboveSizeAsync(minSize);
            return musicList;
        }
        [HttpGet("getAllMusicBelowSize")]
        public async Task<List<MusicDto>> GetAllMusicBelowSize(double minSize)
        {
            var musicList = await _musicService.GetAllMusicBelowSizeAsync(minSize);
            return musicList;
        }
        [HttpGet("getTopMostLikedMusic")]
        public async Task<List<MusicDto>> GetTopMostLikedMusic(int count)
        {
            var musicList = await _musicService.GetTopMostLikedMusicAsync(count);
            return musicList;
        }
        [HttpGet("getTheLessLikedMusic")]
        public async Task<List<MusicDto>> GetTheLessLikedMusic(int count)
        {
            var musicList = await _musicService.GetTheLessLikedMusicAsync(count);
            return musicList;
        }
        [HttpGet("getMusicByDescriptionKeyword")]
        public async Task<List<MusicDto>> GetMusicByDescriptionKeyword(string keyword)
        {
            var musicList = await _musicService.GetMusicByDescriptionKeywordAsync(keyword);
            return musicList;
        }
        [HttpGet("getMusicWithLikesInRange")]
        public async Task<List<MusicDto>> GetMusicWithLikesInRange(int minLikes, int maxLikes)
        {
            var musicList = await _musicService.GetMusicWithLikesInRangeAsync(minLikes, maxLikes);
            return musicList;
        }
        [HttpGet("getAllUniqueAuthors")]
        public async Task<List<string>> GetAllUniqueAuthors()
        {
            var names = await _musicService.GetAllUniqueAuthorsAsync();
            return names;
        }
        [HttpGet("getTotalMusicSizeByAuthor")]
        public async Task<double> GetTotalMusicSizeByAuthor(string authorName)
        {
            var totalMB = await _musicService.GetTotalMusicSizeByAuthorAsync(authorName);
            return totalMB;
        }
    }
}
