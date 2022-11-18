using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   

    public enum stateType
    {
        CustomerReject = 0,
        ProviderReject = 1,
        Acceptted = 2,
    }
    public class Request
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public stateType State { get; set; }
        public DateTime? ProviderStartDate { get; set; }
        public DateTime?  EndDate { get; set; }
        public string? Review { get; set; }
        public string? Description { get; set; }
        public string RequestType { get; set; }
        public string? Img { get; set; }
        public DateTime CustmoerSendDate { get; set; }
        public int? Price { get; set; }
        public decimal? Rate { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [ForeignKey("Provider")]
        public Guid ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public Customer? Customer { get; set; }
    }
}
