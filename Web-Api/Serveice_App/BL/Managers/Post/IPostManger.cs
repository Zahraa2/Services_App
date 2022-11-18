using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IPostManager
{
    public List<PostReadDTO> GetAll();
    public PostReadDTO? GetByID(Guid id);
    public void Add(PostWriteDTO Post);
    public bool Update(PostWriteDTO Post);
    public void Delete(Guid id);
    public List<MediasforPost> GetPostsOfProvider(Guid providerId);
}
