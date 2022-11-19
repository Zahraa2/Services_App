using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class RequestManger : IRequestManger
{
    private readonly IUnitOfWork _unitOfWork;

    public IMapper Mapper { get; }

    public RequestManger(IRequestRepo RequestRepo, IMapper mapper, IUnitOfWork unitOfWork)
    {
        Mapper = mapper;
        _unitOfWork = unitOfWork;
    }



    public void Add(RequestCostemerProviderWriteDTO Request)
    {
        var repo = Mapper.Map<Request>(Request);
        repo.Id = Guid.NewGuid();
        _unitOfWork.RequestRepo.Add(repo);
        _unitOfWork.RequestRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = _unitOfWork.RequestRepo.GetById(id);
        if (repo != null)
            _unitOfWork.RequestRepo.Delete(repo);
    }

    public List<RequestReadDTO> GetAll()
    {
        var repo = _unitOfWork.RequestRepo.GetAll();
        var DTO = Mapper.Map<List<RequestReadDTO>>(repo);
        return DTO;
    }

    public RequestReadDTO? GetByID(Guid id)
    {
        var repo = _unitOfWork.RequestRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<RequestReadDTO>(repo);
        return DTO;
    }

    public bool Update(RequestProviderCustomerWriteDTO Request)
    {
        var repo = _unitOfWork.RequestRepo.GetById(Request.Id);
        if (repo == null)
            return false;

        Mapper.Map(Request, repo);
        _unitOfWork.RequestRepo.SaveChange();
        return true;
    }

    public bool UpdateState(RequestUpdateStateWriteDTO model)
    {
        var repo = _unitOfWork.RequestRepo.GetById(model.Id);
        if (repo == null)
            return false;
        repo.State = model.State;
        _unitOfWork.RequestRepo.SaveChange();
        return true;
    }

    public List<RequestReadDTO> GetCustomerRequests(string CustomerId)
    {
        var customer = _unitOfWork.CustomerRepo.GetCustomerByUserId(CustomerId).id;
        if (customer == null)
        {
            return new List<RequestReadDTO>(); 
        }

        var requests = _unitOfWork.RequestRepo.GetAllCustomerRequsts(customer);
        var DTO = Mapper.Map<List<RequestReadDTO>>(requests);
        return DTO;
    }

    public List<RequestReadDTO> GetProviderRequests(string ProviderId)
    {
        var provider = _unitOfWork.ProviderRepo.GetProviderByUserId(ProviderId).id;
        if (provider == null)
        {
            return new List<RequestReadDTO>();
        }

        var requests = _unitOfWork.RequestRepo.GetAllProviderRequsts(provider);
        var DTO = Mapper.Map<List<RequestReadDTO>>(requests);
        return DTO;
    }
}
