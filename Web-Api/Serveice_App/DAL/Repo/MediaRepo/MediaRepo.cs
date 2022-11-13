using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class MediaRepo : GenericRepo<Media>, IMediaRepo
{
    private readonly DatabaseContext context;

    public MediaRepo(DatabaseContext context) : base(context)
    {
        this.context = context;
    }
}

