using BL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL;

public class AuthContollerUnitOfWork : IAuthContollerUnitOfWork
{
    public IAuthServices AuthServices { get; }
    public UserManager<CustomeUser> UserManager { get; }
    public SignInManager<CustomeUser> SignInManager { get; }
    public IProviderManger ProviderManger { get; }
    public ICustomerManager CustomerManager { get; }

    public AuthContollerUnitOfWork(IAuthServices authServices, UserManager<CustomeUser> userManager, SignInManager<CustomeUser> signInManager, IProviderManger providerManger, ICustomerManager customerManager)
    {
        AuthServices = authServices;
        UserManager = userManager;
        SignInManager = signInManager;
        ProviderManger = providerManger;
        CustomerManager = customerManager;

    }
}
