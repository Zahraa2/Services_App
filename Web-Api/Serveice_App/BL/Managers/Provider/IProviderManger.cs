using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IProviderManger
{
    public List<ProviderReadDTO> GetAll();
    public ProviderReadDTO? GetByID(Guid id);
    public void Add(ProviderWriteDTO Provider);
    public bool Update(ProviderWriteDTO Provider);
    public void Delete(Guid id);
    public ProviderReadDTO GetProviderByUserId(string Id);
}
