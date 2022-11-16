using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestUpdateStateWriteDTO
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProviderId { get; set; }
    public stateType State { get; set; }
}
