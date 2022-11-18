using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Service> services { get; set; } = new HashSet<Service>();
}
