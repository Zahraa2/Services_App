using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderWriteImageDTO
{
    public Guid id { get; set; }
    public IFormFile? image { get; set; }
}
