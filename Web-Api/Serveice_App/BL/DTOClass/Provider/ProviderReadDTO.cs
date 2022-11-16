using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderReadDTO
{
    public Guid id { get; set; }
<<<<<<< HEAD
    public string? Name { get; set; }
    public string? ServiceName { get; set; }
    public string? sammary { get; set; }
    public string? Location { get; set; }

=======
    public string sammary { get; set; } = null!;
>>>>>>> b1a094004979f0297e41a9fa0aa8dbc846bce816
    public decimal AvgRate { get; set; }
    public string? profilePicture { get; set; }
    public ICollection<PostReadDTO> posts {get; set;}
    public ProviderReadDTO()
    {
        posts = new HashSet<PostReadDTO>();
    }
}
