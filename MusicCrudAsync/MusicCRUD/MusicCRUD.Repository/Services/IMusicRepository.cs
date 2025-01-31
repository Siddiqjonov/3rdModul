using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface IMusicRepository
{
    Task<Guid> AddAsync(Music music);
    Task<List<Music>> GetAllAsync();
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Music music);
    Task<Music> GetByIdAsync(Guid id);
}