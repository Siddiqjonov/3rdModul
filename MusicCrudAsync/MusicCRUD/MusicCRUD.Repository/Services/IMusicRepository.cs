using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface IMusicRepository
{
    Task<long> AddAsync(Music music);
    Task<List<Music>> GetAllAsync();
    Task DeleteAsync(long id);
    Task UpdateAsync(Music music);
    Task<Music> GetByIdAsync(long id);
}