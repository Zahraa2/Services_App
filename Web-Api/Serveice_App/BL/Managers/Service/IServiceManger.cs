using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IServiceManger
{
    public List<ServiceReadDTO> GetAll();
    public ServiceReadDTO? GetByID(Guid id);
    public void Add(ServiceWriteDTO Service);
    public bool Update(ServiceWriteDTO Service);
    public void Delete(Guid id);
    public List<ServiceReadDTO> GetServicesByCategory(string Name);
    public List<ServiceReadDTO> GetMostServices();
}
