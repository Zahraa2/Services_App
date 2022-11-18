using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IMediaRepo:IGenericRepo<Media>
{
    public List<string> GetimgsOfPost(Guid postId);
    public List<Media> GetMediaOfPost(Guid postId);
}
