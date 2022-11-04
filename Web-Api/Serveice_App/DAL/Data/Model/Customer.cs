using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Customer
{
    public Guid id { get; set; }
    [ForeignKey("user")]
    public string UserId { get; set; } = null!;
    public CustomeUser user { get; set; } = null!;

    public ICollection<Request> requests = new HashSet<Request>();
}
