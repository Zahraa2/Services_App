using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IProviderUser
    {
        public ProviderUserReadDTO ProviderUserReadDTO(Provider provider);
        public List<ProviderUserReadDTO>? GetAllProviders(string Name);
       public ProviderReadDTO? GetProviderbyid(Guid id);
        public bool EditProvider(ProviderUserWriteDTO provider);

    }
}
