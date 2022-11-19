using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderUserWriteDTO
{
    public Guid id { get; set; }
    public Guid? ServiceId { get; set; }
    public string? sammary { get; set; }
    public string? profilePicture { get; set; }
    //Name just take all name to split it to Fname and Lname
    public string Name { get; set; }
    public string Fname { get; set; } = "";
    public string Lname { get; set; } = "";
    public string City { get; set; }



}
