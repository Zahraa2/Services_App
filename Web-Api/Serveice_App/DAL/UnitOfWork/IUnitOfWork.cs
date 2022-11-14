using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IUnitOfWork
{
    ICategoryRepo CategoryRepo { get; }
    ICustomerRepo CustomerRepo { get; }
    IMediaRepo MediaRepo { get; }   
    IPostRepo PostRepo { get; } 
    IProviderRepo ProviderRepo { get; }
    IRequestRepo RequestRepo { get; }
    IServiceRepo ServiceRepo { get; }
    IUserRepo userRepo { get; }
}
