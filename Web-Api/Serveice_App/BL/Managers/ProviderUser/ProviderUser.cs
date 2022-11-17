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

    public ProviderUserReadDTO ProviderUserReadDTO(Provider provider)
    {
        var Provider_DTO = _mapper.Map<ProviderUserReadDTO>(provider);
        Provider_DTO.ServiceName = _unitOfWork.ServiceRepo.GetById(provider.ServiceId).Name;
        var User = _unitOfWork.userRepo.GetUserById(provider.UserId);
        Provider_DTO.Name = User.Fname + " " + User.Lname;
        return Provider_DTO;
    }

    
}
