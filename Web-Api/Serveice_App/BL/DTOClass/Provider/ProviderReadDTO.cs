using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderReadDTO
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public string? ServiceName { get; set; }
    public string? sammary { get; set; }
    public string? Location { get; set; }
    public decimal AvgRate { get; set; }
    public string? profilePicture { get; set; }
<<<<<<< HEAD
    
=======
    public ICollection<PostReadDTO> posts {get; set;}
    public ProviderReadDTO()
    {
        posts = new HashSet<PostReadDTO>();
    }
>>>>>>> db949ac9e3efaf1a31a27955f496fb16c3127ee7
}
