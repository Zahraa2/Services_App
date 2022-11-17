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

<<<<<<< HEAD

=======
>>>>>>> db949ac9e3efaf1a31a27955f496fb16c3127ee7
    //get all providers by service name
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
<<<<<<< HEAD

    public ProviderReadDTO GetProviderbyid(Guid id)
    {
        var provider = _unitOfWork.ProviderRepo.GetById(id);
        var providerReadDTO = _mapper.Map<ProviderReadDTO>(provider);
=======
    // function Get All data About Provider with his Posts and Medias
    public ProviderReadDTO? GetProviderbyid(Guid id)
    {
        Provider? provider = _unitOfWork.ProviderRepo.SelectAlldata(id);
        if (provider == null)
            return null;
        ProviderReadDTO providerReadDTO = _mapper.Map<ProviderReadDTO>(provider);
>>>>>>> db949ac9e3efaf1a31a27955f496fb16c3127ee7
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
