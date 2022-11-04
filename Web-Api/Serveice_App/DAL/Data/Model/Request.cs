using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Request
    {
        public Guid Id { get; set; }
        public string? Location { get; set; }
        public string? State { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime  EndDate { get; set; }
        public string? Review { get; set; }
        public decimal Rate { get; set; }
        [ForeignKey("Customer")]
        public Guid? CustomerId { get; set; }
        [ForeignKey("Provider")]
        public Guid? ProviderId { get; set; }
        public Provider? Provider { get; set; }
        public Customer? Customer { get; set; }
    }
}
