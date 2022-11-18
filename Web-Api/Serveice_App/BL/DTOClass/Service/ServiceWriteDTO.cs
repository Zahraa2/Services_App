using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ServiceWriteDTO
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public Guid? categoryId { get; set; }
}
