using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderUser : IProviderUser
{
    //private readonly UnitOfWork _unitOfWork;
    private readonly IProviderRepo _providerRepo;
    private readonly IServiceRepo _serviceRepo;
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    public ProviderUser( IMapper mapper, IProviderRepo providerRepo, IServiceRepo serviceRepo, IUserRepo userRepo)
    {
        //_unitOfWork = unitOfWork;
        _mapper = mapper;
        _providerRepo = providerRepo;
        _serviceRepo = serviceRepo;
        _userRepo = userRepo;
    }
    //Edit data Of provider in user Table and Provider Table
    public bool EditProvider(ProviderUserWriteDTO provider)
    {
        var VarProviderRepo = _providerRepo.GetById(provider.id);
        if (VarProviderRepo == null)
            return false;
        _mapper.Map(provider, VarProviderRepo);
        provider.Fname = provider.Name.Split(" ")[0];
        for (int i = 1; i < provider.Name.Split(' ').Length; i++)
        {
            provider.Lname += provider.Name.Split(" ")[i];
            if (i != provider.Name.Split(' ').Length-1)
            {
                provider.Lname += " ";
            }
        }
        var customRepo = _providerRepo.GetUserByProviderID(provider.id);
        customRepo.City = provider.City;
        customRepo.Fname = provider.Fname;
        customRepo.Lname = provider.Lname;
        //_mapper.Map(provider, customRepo);
        _providerRepo.SaveChange();
        return true;
    }

    public List<ProviderUserReadDTO>? GetAllProviders(string Name)
    {
       
        var Service = _serviceRepo.GetAll().FirstOrDefault(s => s.Name == Name);
        if (Service == null)
            return null;
        var Providers = _providerRepo.GetAll()
            .Where(p => p.ServiceId == Service.id);
        if (Providers == null)
            return null;
        List<ProviderUserReadDTO> providerUserReadDTO = new List<ProviderUserReadDTO>();
        foreach(Provider p in Providers)
        {
            providerUserReadDTO.Add(ProviderUserReadDTO(p));
        }
        return providerUserReadDTO;
    }
    // function Get All data About Provider with his Posts and Medias
    public ProviderReadDTO? GetProviderbyid(Guid id)
    {
        Provider? provider = _providerRepo.SelectAlldata(id);
        if (provider == null)
            return null;
        ProviderReadDTO providerReadDTO = _mapper.Map<ProviderReadDTO>(provider);
        var Service = _serviceRepo.GetById(provider.ServiceId);
        providerReadDTO.ServiceName= Service.Name;
        providerReadDTO.ServiceID= Service.id;
        var User = _userRepo.GetUserById(provider.UserId);
        providerReadDTO.Name = User.Fname + " " + User.Lname;
        providerReadDTO.Location = User.City;
        return providerReadDTO;
    }
    // map Provider to ProviderUser 
    public ProviderUserReadDTO ProviderUserReadDTO(Provider provider)
    {
        var Provider_DTO = _mapper.Map<ProviderUserReadDTO>(provider);
        Provider_DTO.ServiceName = _serviceRepo.GetById(provider.ServiceId).Name;
        var User = _userRepo.GetUserById(provider.UserId);
        Provider_DTO.Name = User.Fname + " " + User.Lname;
        return Provider_DTO;
    }




    
}
