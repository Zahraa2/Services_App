using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderUserReadDTO
{
	public Guid id { get; set; }
	public string? Name { get; set; }
	public string? profilePicture { get; set; }
	public decimal AvgRate { get; set; }
	public string? ServiceName  { get; set; }
}
