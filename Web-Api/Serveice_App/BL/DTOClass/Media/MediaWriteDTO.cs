using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class MediaWriteDTO
{
    public Guid Id { get; set; }
    public Guid? PostId { get; set; }
    public string Image { get; set; } = null!;
}
