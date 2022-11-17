using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ServiceManger : IServiceManger
{
    private readonly IServiceRepo ServiceRepo;
    private readonly IUnitOfWork unitOfWork;

    public IMapper Mapper { get; }

    public ServiceManger(IServiceRepo ServiceRepo, IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.ServiceRepo = ServiceRepo;
        Mapper = mapper;
        this.unitOfWork = unitOfWork;
    }



    public void Add(ServiceWriteDTO Service)
    {
        var repo = Mapper.Map<Service>(Service);
        repo.id = Guid.NewGuid();
        ServiceRepo.Add(repo);
        ServiceRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = ServiceRepo.GetById(id);
        if (repo != null)
            ServiceRepo.Delete(repo);
    }

    public List<ServiceReadDTO> GetAll()
    {
        var repo = ServiceRepo.GetAll();
        var DTO = Mapper.Map<List<ServiceReadDTO>>(repo);
        foreach(ServiceReadDTO Service in DTO)
        {
            Service.NumberOfProviders=unitOfWork.ProviderRepo.GetAll().Where(p=>p.ServiceId==Service.id).Count();
        }
        return DTO;
    }

    public ServiceReadDTO? GetByID(Guid id)
    {
        var repo = ServiceRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<ServiceReadDTO>(repo);
        return DTO;
    }

    public bool Update(ServiceWriteDTO Service)
    {
        var repo = ServiceRepo.GetById(Service.id);
        if (repo == null)
            return false;

        Mapper.Map(Service, repo);
        ServiceRepo.SaveChange();
        return true;
    }

    public List<ServiceReadDTO> GetServicesByCategory(string Name)
    {
        var DTO = Mapper.Map<List<ServiceReadDTO>>(ServiceRepo.GetServicesByCategory(Name));
        if (DTO.Count == 0)
            return null;

        foreach (ServiceReadDTO Service in DTO)
        {
            Service.NumberOfProviders = unitOfWork.ProviderRepo.GetAll().Where(p => p.ServiceId == Service.id).Count();
        }
        return DTO;
    }

    public List<ServiceReadDTO> GetMostServices()
    {
        var DTO = Mapper.Map<List<ServiceReadDTO>>(ServiceRepo.GetMostServices());
        foreach (ServiceReadDTO Service in DTO)
        {
            Service.NumberOfProviders = unitOfWork.ProviderRepo.GetAll().Where(p => p.ServiceId == Service.id).Count();
        }
        return DTO;
    }
}
