using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class CustomerManger:ICustomerManager
{
    private readonly ICustomerRepo CustomerRepo;
    public IMapper Mapper { get; }

    public CustomerManger(ICustomerRepo CustomerRepo, IMapper mapper)
    {
        this.CustomerRepo = CustomerRepo;
        Mapper = mapper;
    }



    public void Add(CustomerWriteDTO Customer)
    {
        var repo = Mapper.Map<Customer>(Customer);
        repo.id = Guid.NewGuid();
        CustomerRepo.Add(repo);
        CustomerRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = CustomerRepo.GetById(id);
        if (repo != null)
            CustomerRepo.Delete(repo);
    }

    public List<CustomerReadDTO> GetAll()
    {
        var repo = CustomerRepo.GetAll();
        var DTO = Mapper.Map<List<CustomerReadDTO>>(repo);
        return DTO;
    }

    public CustomerReadDTO? GetByID(Guid id)
    {
        var repo = CustomerRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<CustomerReadDTO>(repo);
        return DTO;
    }

    public bool Update(CustomerWriteDTO Customer)
    {
        var repo = CustomerRepo.GetById(Customer.id);
        if (repo == null)
            return false;

        Mapper.Map(Customer, repo);
        CustomerRepo.SaveChange();
        return true;
    }

    public CustomerReadDTO GetCustomerByUserId(string Id)
    {
        var customer = CustomerRepo.GetCustomerByUserId(Id);
        var DTO = Mapper.Map<CustomerReadDTO>(customer);
        return DTO;
    }
}

