using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class RequestRepo : GenericRepo<Request>, IRequestRepo
{
    private readonly DatabaseContext context;

    public RequestRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }

    public List<Request> GetAllCustomerRequsts(Guid CustomerId)
    {
        var request = context.Requests.Where(c => c.CustomerId == CustomerId).ToList();
        return request;
    }

    public List<Request> GetAllProviderRequsts(Guid PrpviderId)
    {
        var request = context.Requests.Where(p => p.ProviderId == PrpviderId).ToList();
        return request;
    }
}
