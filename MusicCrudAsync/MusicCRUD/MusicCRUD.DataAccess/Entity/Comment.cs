using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess.Entity;

public class Comment
{
    public long CommentId { get; set; }
    public string Content { get; set; }
    public DateTime CtreatedTime { get; set; }
    public long MusicId { get; set; } // foreignKey
    public Music Music { get; set; }
}
