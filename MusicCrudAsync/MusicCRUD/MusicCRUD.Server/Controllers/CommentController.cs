using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Services;

namespace MusicCRUD.Server.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("addComment")]
    public async Task<long> AddComment(CommentDto comment)
    {
        var id = await _commentService.AddCommentAsync(comment);
        return id;
    }

}
