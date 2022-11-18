using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Media
{
    public Guid Id { get; set; }
    [ForeignKey("Post")]
    public Guid? PostId { get; set; }
    public string? Image { get; set; } 
    public Post? Post { get; set; } 
}
