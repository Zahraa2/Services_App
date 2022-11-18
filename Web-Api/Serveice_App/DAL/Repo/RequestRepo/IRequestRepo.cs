using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IRequestRepo:IGenericRepo<Request>
{
    public List<Request> GetAllCustomerRequsts(Guid CustomerId);
    public List<Request> GetAllProviderRequsts(Guid PrpviderId);

}
