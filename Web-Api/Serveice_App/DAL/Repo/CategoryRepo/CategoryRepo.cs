using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    private readonly DatabaseContext context;

    public CategoryRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }
}
