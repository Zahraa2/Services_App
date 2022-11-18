using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepo CategoryRepo { get; }

    public ICustomerRepo CustomerRepo { get; }

    public IMediaRepo MediaRepo { get; }

    public IPostRepo PostRepo { get; }

    public IProviderRepo ProviderRepo { get; }

    public IRequestRepo RequestRepo { get; }

    public IServiceRepo ServiceRepo { get; }
    public IUserRepo userRepo  { get;}

    public UnitOfWork(ICategoryRepo categoryRepo,ICustomerRepo customerRepo,IMediaRepo mediaRepo ,IPostRepo postRepo,IProviderRepo providerRepo,IRequestRepo requestRepo,IServiceRepo serviceRepo, IUserRepo userRepo)
    {
        this.CategoryRepo = categoryRepo;
        this.CustomerRepo = customerRepo;
        this.MediaRepo = mediaRepo;
        this.PostRepo = postRepo;   
        this.ProviderRepo = providerRepo;
        this.RequestRepo = requestRepo;
        this.ServiceRepo = serviceRepo;
        this.userRepo = userRepo;
    }
}
