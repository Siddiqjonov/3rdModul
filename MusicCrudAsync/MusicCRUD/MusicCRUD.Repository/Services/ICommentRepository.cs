using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface ICommentRepository
{
    Task<long> AddCommentAsync(Comment commennt);
}