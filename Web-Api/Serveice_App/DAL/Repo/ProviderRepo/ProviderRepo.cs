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

    public List<Provider> GetProvidersByService(string Name)
    {
        return context.Provider.Include(s => s.service).Where(s => s.service.Name == Name).ToList();
    }

}
