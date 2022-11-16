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
<<<<<<< HEAD:Web-Api/Serveice_App/BL/Mangers/ProviderUser/IProviderUser.cs
       public ProviderReadDTO? GetProviderbyid(Guid id);
=======
        //public ProviderUserReadDTO? GetProviderbyid(Guid id);
>>>>>>> b1a094004979f0297e41a9fa0aa8dbc846bce816:Web-Api/Serveice_App/BL/Managers/ProviderUser/IProviderUser.cs

    }
}
