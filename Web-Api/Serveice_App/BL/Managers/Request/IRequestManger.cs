using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IRequestManger
{
    public List<RequestReadDTO> GetAll();
    public RequestReadDTO? GetByID(Guid id);
    public void Add(RequestWriteDTO Request);
    public bool Update(RequestWriteDTO Request);
    public void Delete(Guid id);
}
