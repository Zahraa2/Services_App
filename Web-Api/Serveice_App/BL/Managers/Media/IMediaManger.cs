using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IMediaManger
{
    public List<MediaReadDTO> GetAll();
    public MediaReadDTO? GetByID(Guid id);
    public void Add(MediaWriteDTO Media);
    public bool Update(MediaWriteDTO Media);
    public void Delete(Guid id);
}
