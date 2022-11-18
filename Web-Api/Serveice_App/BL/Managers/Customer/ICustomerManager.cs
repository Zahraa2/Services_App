using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface ICustomerManager
{
    public List<CustomerReadDTO> GetAll();
    public CustomerReadDTO? GetByID(Guid id);
    public void Add(CustomerWriteDTO Customer);
    public bool Update(CustomerWriteDTO Customer);
    public void Delete(Guid id);

    public CustomerReadDTO GetCustomerByUserId(string Id);
}
