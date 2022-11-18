using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ServiceReadDTO
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public int NumberOfProviders { get; set; }
}
