using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class PostWriteDTO
{
    public Guid Id { get; set; }
    public string? Description { get; set; } 
    public string? Image { get; set; }
    [Required]
    public Guid ProviderId { get; set; }
}
