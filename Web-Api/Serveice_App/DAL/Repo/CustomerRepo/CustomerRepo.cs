using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class CutomerRepo : GenericRepo<Customer>, ICustomerRepo
{
    private readonly DatabaseContext context;

    public CutomerRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }
}
