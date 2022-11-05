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
}
