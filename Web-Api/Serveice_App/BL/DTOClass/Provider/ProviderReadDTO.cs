using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderReadDTO
{
    public Guid id { get; set; }
    public string sammary { get; set; } = null!;
    public decimal AvgRate { get; set; }
    public string profilePicture { get; set; } = null!;
}
