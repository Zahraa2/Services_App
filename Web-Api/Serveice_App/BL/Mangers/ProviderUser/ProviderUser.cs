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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProviderUser(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper; 
    }

    //get all providers by service name
    public List<ProviderUserReadDTO>? GetAllProviders(string Name)
    {
        var Service = _unitOfWork.ServiceRepo.GetAll().First(s => s.Name == Name);
        var Providers = _unitOfWork.ProviderRepo.GetAll()
            .Where(p => p.ServiceId == Service.id);

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
