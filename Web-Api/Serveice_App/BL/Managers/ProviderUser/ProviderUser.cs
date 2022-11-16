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
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProviderUser(UnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper; 
    }

<<<<<<< HEAD:Web-Api/Serveice_App/BL/Mangers/ProviderUser/ProviderUser.cs
    //get all providers by service name
=======
>>>>>>> b1a094004979f0297e41a9fa0aa8dbc846bce816:Web-Api/Serveice_App/BL/Managers/ProviderUser/ProviderUser.cs
    public List<ProviderUserReadDTO>? GetAllProviders(string Name)
    {
       
        var Service = _unitOfWork.ServiceRepo.GetAll().FirstOrDefault(s => s.Name == Name);
        if (Service == null)
            return null;
        var Providers = _unitOfWork.ProviderRepo.GetAll()
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
        Provider? provider = _unitOfWork.ProviderRepo.SelectAlldata(id);
        if (provider == null)
            return null;
        ProviderReadDTO providerReadDTO = _mapper.Map<ProviderReadDTO>(provider);
        providerReadDTO.ServiceName= _unitOfWork.ServiceRepo.GetById(provider.ServiceId).Name;
        var User = _unitOfWork.userRepo.GetUserById(provider.UserId);
        providerReadDTO.Name = User.Fname + " " + User.Lname;
        providerReadDTO.Location = User.City;
        return providerReadDTO;
    }
    // map Provider to ProviderUser 
    public ProviderUserReadDTO ProviderUserReadDTO(Provider provider)
    {
        var Provider_DTO = _mapper.Map<ProviderUserReadDTO>(provider);
        Provider_DTO.ServiceName = _unitOfWork.ServiceRepo.GetById(provider.ServiceId).Name;
        var User = _unitOfWork.userRepo.GetUserById(provider.UserId);
        Provider_DTO.Name = User.Fname + " " + User.Lname;
        return Provider_DTO;
    }




    
}
