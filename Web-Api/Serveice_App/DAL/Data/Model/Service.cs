using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class Service
{
    public Guid id { get; set; }
    public string? Name { get; set; }
    public int NumberOfOrders { get; set; }

    [ForeignKey("category")]
    public Guid? categoryId { get; set; }
    public ICollection<Provider> provider { get; set; } = new HashSet<Provider>();
    public Category category { get; set; } = null!;
}
