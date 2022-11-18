using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class ProviderRepo : GenericRepo<Provider>, IProviderRepo
{
    private readonly DatabaseContext context;

    public ProviderRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }

    public List<Provider> GetProviderByServices(string Name)
    {
        Service service = context.Services.First(s => s.Name == Name);
        var providers = context.Provider.Where(P => P.ServiceId == service.id).ToList();
        return providers;
    }

    public Provider GetProviderByUserId(string Id)
    {
        Provider provider = context.Provider.FirstOrDefault(u => u.UserId == Id);
        return provider;
    }

    public List<Provider> GetProvidersByService(string Name)
    {
        return context.Provider.Include(s => s.service).Where(s => s.service.Name == Name).ToList();
    }

    public CustomeUser GetUserByProviderID(Guid Id)
    {
        return context.customeUsers.Include(c => c.provider).FirstOrDefault(cd => cd.provider.id == Id);
    }

    public  Provider? SelectAlldata(Guid id)
    {

        Provider? provider = context.Provider.Include(po => po.posts).ThenInclude(post=>post.Medias).FirstOrDefault(p=>p.id==id);
        return provider;
       
    }
}
