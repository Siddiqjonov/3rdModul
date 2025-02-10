using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Service.DTOs;

public class CommentGetDto
{
    public long CommentId { get; set; }
    public string Content { get; set; }
    public DateTime CtreatedTime { get; set; }
    public long MusicId { get; set; } // foreignKey
}
