using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Provider
{
    public Guid id { get; set; }
    [ForeignKey("user")]
    public string? UserId { get; set; }
    [ForeignKey("service")]
    public Guid? ServiceId { get; set; }
    public CustomeUser? user { get; set; } 

    public string? sammary { get; set; } 

    public decimal? AvgRate { get; set; }
    
    public string? profilePicture { get; set; } 
    public ICollection<Request> requests = new HashSet<Request>();
    public ICollection<Post>? posts { get; set; }
    public Service? service { get; set; }
    public Provider()
    {
        posts = new HashSet<Post>();
    }

}
