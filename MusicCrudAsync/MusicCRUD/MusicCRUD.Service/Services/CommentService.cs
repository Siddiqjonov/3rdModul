using MusicCRUD.DataAccess.Entity;
using MusicCRUD.Repository.Services;
using MusicCRUD.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Service.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<long> AddCommentAsync(CommentDto commentDto)
    {
        var id = await _commentRepository.AddCommentAsync(ConvertToEntity(commentDto));
        return id;
    }

    private Comment ConvertToEntity(CommentDto commentDto)
    {
        return new Comment()
        {
            Content = commentDto.Content,
            MusicId = commentDto.MusicId,
            CtreatedTime = DateTime.UtcNow
        };
    }
}
