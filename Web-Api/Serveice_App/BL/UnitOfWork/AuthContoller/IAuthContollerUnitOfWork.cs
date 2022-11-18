using BL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL;

public interface IAuthContollerUnitOfWork
{
    IAuthServices AuthServices { get; }
    UserManager<CustomeUser> UserManager { get; }
    SignInManager<CustomeUser> SignInManager { get; }
    IProviderManger ProviderManger { get; } 
    ICustomerManager CustomerManager { get; }
}
