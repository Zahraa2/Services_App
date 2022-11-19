using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL;


public class RequestCostemerProviderWriteDTO
{
    public string Name { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProviderId { get; set; }
    public string? Description { get; set; }
    public string RequestType { get; set; }
    public string? Img { get; set; }
    public string Location { get; set; }
    public DateTime CustmoerSendDate { get; set; }
    public string message { get; set; }

}
