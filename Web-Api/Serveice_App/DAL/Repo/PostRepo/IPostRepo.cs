using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IPostRepo:IGenericRepo<Post>
{
    public List<Post> GetPostsOfProvider(Guid providerId);
}
