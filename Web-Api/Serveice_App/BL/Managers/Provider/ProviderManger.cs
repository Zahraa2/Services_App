using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class ProviderManger : IProviderManger
{
    private readonly IProviderRepo ProviderRepo;
    public IMapper Mapper { get; }

    public ProviderManger(IProviderRepo ProviderRepo, IMapper mapper)
    {
        this.ProviderRepo = ProviderRepo;
        Mapper = mapper;
    }



    public void Add(ProviderWriteDTO Provider)
    {
        var repo = Mapper.Map<Provider>(Provider);
        repo.id = Guid.NewGuid();
        ProviderRepo.Add(repo);
        ProviderRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = ProviderRepo.GetById(id);
        if (repo != null)
            ProviderRepo.Delete(repo);
    }

    public List<ProviderReadDTO> GetAll()
    {
        var repo = ProviderRepo.GetAll();
        var DTO = Mapper.Map<List<ProviderReadDTO>>(repo);
        return DTO;
    }

    public ProviderReadDTO? GetByID(Guid id)
    {
        var repo = ProviderRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<ProviderReadDTO>(repo);
        return DTO;
    }

    public bool Update(ProviderWriteDTO Provider)
    {
        var repo = ProviderRepo.GetById(Provider.id);
        if (repo == null)
            return false;

        Mapper.Map(Provider, repo);
        ProviderRepo.SaveChange();
        return true;
    }

    public ProviderReadDTO GetProviderByUserId(string Id)
    {
        var provider = ProviderRepo.GetProviderByUserId(Id);
        var DTO = Mapper.Map<ProviderReadDTO>(provider);
        return DTO;
    }
}
