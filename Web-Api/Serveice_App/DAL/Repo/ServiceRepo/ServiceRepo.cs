using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class ServiceRepo : GenericRepo<Service>, IServiceRepo
{
    private readonly DatabaseContext context;

    public ServiceRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }

    public List<Service> GetMostServices()
    {
        const int mx = 6;
        List<Service> services =context.Services.OrderBy(s => s.NumberOfOrders).ToList();
        List<Service> mx_services = new List<Service>();
        int len = services.Count - 1;
        int len_cp = len;
        for (int i = 0; i <= Math.Min(6, len_cp);i++)
        {
            mx_services.Add(services[len--]);
        }
        return mx_services;
    }

    public List<Service> GetServicesByCategory(string Name)
    {
        return context.Services.Include(c=>c.category).Where(s=>s.category.Name==Name).ToList();
    }
}
