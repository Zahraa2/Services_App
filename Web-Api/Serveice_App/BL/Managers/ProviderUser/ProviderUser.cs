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
        providerReadDTO.ServiceName= _serviceRepo.GetById(provider.ServiceId).Name;
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
