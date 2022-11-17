using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BL;

public class ProviderUser : IProviderUser
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DatabaseContext _context;

    public ProviderUser(IUnitOfWork unitOfWork, IMapper mapper, DatabaseContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _context = context;
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

    public ProviderReadDTO GetProviderbyid(Guid id)
    {
        var provider = _unitOfWork.ProviderRepo.GetById(id);
        var providerReadDTO = _mapper.Map<ProviderReadDTO>(provider);
        providerReadDTO.ServiceName= _unitOfWork.ServiceRepo.GetById(provider.ServiceId).Name;
        var User = _unitOfWork.userRepo.GetUserById(provider.UserId);
        providerReadDTO.Name = User.Fname + " " + User.Lname;
        providerReadDTO.Location = User.City;
        return providerReadDTO;
    }

    public ProviderUserReadDTO ProviderUserReadDTO(Provider provider)
    {
        var Provider_DTO = _mapper.Map<ProviderUserReadDTO>(provider);
        Provider_DTO.ServiceName = _unitOfWork.ServiceRepo.GetById(provider.ServiceId).Name;
        var User = _unitOfWork.userRepo.GetUserById(provider.UserId);
        Provider_DTO.Name = User.Fname + " " + User.Lname;
        return Provider_DTO;
    }

    public void SetImage(ProviderWriteImageDTO ProviderImage)
    {
        
        MemoryStream ms = new MemoryStream();
        ProviderImage.image.CopyTo(ms);

        Images i = new Images();
        ProviderImage.id = Guid.NewGuid();
        i.Id = ProviderImage.id;
        i.image = ms.ToArray();
        ms.Close();
        ms.Dispose();
        _context.Images.Add(i);
        _context.SaveChanges();

    }



}
