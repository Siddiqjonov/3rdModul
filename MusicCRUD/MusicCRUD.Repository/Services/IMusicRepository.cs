using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface IMusicRepository
{
    Guid Add(Music music);
    List<Music> GetAll();
    void Delete(Guid id);
    void Update(Music music);
    Music GetById(Guid id);
}