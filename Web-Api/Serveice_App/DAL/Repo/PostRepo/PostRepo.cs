using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class PostRepo : GenericRepo<Post>, IPostRepo
{
    private readonly DatabaseContext context;

    public PostRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }
}
