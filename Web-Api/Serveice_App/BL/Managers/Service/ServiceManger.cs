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
    private readonly IUnitOfWork unitOfWork;

    public IMapper Mapper { get; }

    public ServiceManger(IUnitOfWork unitOfWork, IMapper mapper)
    {
        Mapper = mapper;
        this.unitOfWork = unitOfWork;
    }



    public void Add(ServiceWriteDTO Service)
    {
        var repo = Mapper.Map<Service>(Service);
        repo.id = Guid.NewGuid();
        unitOfWork.ServiceRepo.Add(repo);
        unitOfWork.ServiceRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = unitOfWork.ServiceRepo.GetById(id);
        if (repo != null)
            unitOfWork.ServiceRepo.Delete(repo);
    }

    public List<ServiceReadDTO> GetAll()
    {
        var repo = unitOfWork.ServiceRepo.GetAll();
        var DTO = Mapper.Map<List<ServiceReadDTO>>(repo);
        foreach(ServiceReadDTO Service in DTO)
        {
            Service.NumberOfProviders = unitOfWork.ProviderRepo.GetAll().Where(p=>p.ServiceId==Service.id).Count();
        }
        return DTO;
    }

    public ServiceReadDTO? GetByID(Guid id)
    {
        var repo = unitOfWork.ServiceRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<ServiceReadDTO>(repo);
        return DTO;
    }

    public bool Update(ServiceWriteDTO Service)
    {
        var repo = unitOfWork.ServiceRepo.GetById(Service.id);
        if (repo == null)
            return false;

        Mapper.Map(Service, repo);
        unitOfWork.ServiceRepo.SaveChange();
        return true;
    }

    public List<ServiceReadDTO> GetServicesByCategory(string Name)
    {
        var DTO = Mapper.Map<List<ServiceReadDTO>>(unitOfWork.ServiceRepo.GetServicesByCategory(Name));
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
        var DTO = Mapper.Map<List<ServiceReadDTO>>(unitOfWork.ServiceRepo.GetMostServices());
        foreach (ServiceReadDTO Service in DTO)
        {
            Service.NumberOfProviders = unitOfWork.ProviderRepo.GetAll().Where(p => p.ServiceId == Service.id).Count();
        }
        return DTO;
    }
}
