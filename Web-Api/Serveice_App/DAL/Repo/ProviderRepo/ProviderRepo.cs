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
}
