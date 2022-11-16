using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestManger : IRequestManger
{
    private readonly IRequestRepo RequestRepo;
    public IMapper Mapper { get; }

    public RequestManger(IRequestRepo RequestRepo, IMapper mapper)
    {
        this.RequestRepo = RequestRepo;
        Mapper = mapper;
    }



    public void Add(RequestCostemerProviderWriteDTO Request)
    {
        var repo = Mapper.Map<Request>(Request);
        repo.Id = Guid.NewGuid();
        RequestRepo.Add(repo);
        RequestRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = RequestRepo.GetById(id);
        if (repo != null)
            RequestRepo.Delete(repo);
    }

    public List<RequestReadDTO> GetAll()
    {
        var repo = RequestRepo.GetAll();
        var DTO = Mapper.Map<List<RequestReadDTO>>(repo);
        return DTO;
    }

    public RequestReadDTO? GetByID(Guid id)
    {
        var repo = RequestRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<RequestReadDTO>(repo);
        return DTO;
    }

    public bool Update(RequestProviderCustomerWriteDTO Request)
    {
        var repo = RequestRepo.GetById(Request.Id);
        if (repo == null)
            return false;

        Mapper.Map(Request, repo);
        RequestRepo.SaveChange();
        return true;
    }

    public bool UpdateState(RequestUpdateStateWriteDTO model)
    {
        var repo = RequestRepo.GetById(model.Id);
        if (repo == null)
            return false;
        repo.State = model.State;
        RequestRepo.SaveChange();
        return true;
    }
}
