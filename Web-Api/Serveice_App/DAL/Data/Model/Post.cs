using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Post
{
    public Guid Id { get; set; }
    public string? Description { get; set; } = null!;
    [ForeignKey("provider")]
    public Guid? ProviderID { get; set; }
    public Provider Provider { get; set; } = null!;
    public ICollection<Media>? Medias { get; set; }
    public Post()
    {
        Medias = new HashSet<Media>();
    }
}
