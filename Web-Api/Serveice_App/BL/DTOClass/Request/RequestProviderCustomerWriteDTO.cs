using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestProviderCustomerWriteDTO
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProviderId { get; set; }
    public DateTime ProviderStartDate { get; set; }
    public int Price { get; set; }
    public string PhoneNumber { get; set; }
    public string message { get; set; }

}
