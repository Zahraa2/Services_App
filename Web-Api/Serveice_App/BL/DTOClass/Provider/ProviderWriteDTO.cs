using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderWriteDTO
{
    public Guid id { get; set; }
    public string? UserId { get; set; }
    public Guid? ServiceId { get; set; }
    public string sammary { get; set; } = null!;
    public decimal AvgRate { get; set; }
    public string profilePicture { get; set; } = null!;
}
