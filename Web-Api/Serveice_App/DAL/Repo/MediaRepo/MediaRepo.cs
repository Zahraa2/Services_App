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

    public List<string> GetimgsOfPost(Guid postId)
    {
        var imgs = context.Medias.Where(p=>p.PostId == postId).Select(i=> i.Image).ToList();
        return imgs;

    }

    public List<Media> GetMediaOfPost(Guid postId)
    {
        return context.Medias.Where(m=>m.PostId==postId).ToList();
    }
}

