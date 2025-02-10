using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Services;

public interface ICommentService
{
    Task<long> AddCommentAsync(CommentDto commentDto);
}