using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestWriteDTO
{
    public Guid Id { get; set; }
    public string? Location { get; set; }
    public string? State { get; set; }
    public string CreateDate { get; set; }
    public string EndDate { get; set; }
    public string? Review { get; set; }
    public decimal Rate { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? ProviderId { get; set; }
    public string RequestType { get; set; }
}
