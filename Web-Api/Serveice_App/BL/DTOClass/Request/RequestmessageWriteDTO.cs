using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestmessageWriteDTO
{
    public Guid ProviderId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string RequestType { get; set; }
}
