using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class CustomerWriteDTO
{
    public Guid id { get; set; }
    public string UserId { get; set; } = null!;
}
