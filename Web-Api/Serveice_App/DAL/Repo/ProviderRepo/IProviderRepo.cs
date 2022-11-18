using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IProviderRepo:IGenericRepo<Provider>
{
    public List<Provider> GetProvidersByService(string Name);
    public List<Provider> GetProviderByServices(string Name);
    public Provider SelectAlldata(Guid id);
    public Provider GetProviderByUserId(string Id);

    public CustomeUser GetUserByProviderID(Guid Id);

}
