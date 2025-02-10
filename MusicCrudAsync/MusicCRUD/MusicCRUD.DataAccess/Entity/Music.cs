using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess.Entity;

public class Music
{
    //[Key]
    public long MusicId { get; set; }
    //[Required]
    //[StringLength(30)]
    public string Name { get; set; }
    public double MB { get; set; }
    //[Required]
    //[StringLength(20, MinimumLength = 2)]
    public string AuthorName { get; set; }
    public string Description { get; set; }
    public int QuentityLikes { get; set; }
    public List<Comment> Commetns { get; set; }
}
