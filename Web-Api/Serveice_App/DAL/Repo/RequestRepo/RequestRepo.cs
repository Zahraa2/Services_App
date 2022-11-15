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
}
