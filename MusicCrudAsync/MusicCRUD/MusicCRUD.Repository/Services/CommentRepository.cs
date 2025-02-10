using MusicCRUD.DataAccess;
using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Repository.Services;

public class CommentRepository : ICommentRepository
{
    private MainContext _mainContext;

    public CommentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddCommentAsync(Comment commennt)
    {
        await _mainContext.Comments.AddAsync(commennt);
        await _mainContext.SaveChangesAsync();
        return commennt.CommentId;
    }
}
