﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface IRequestManger
{
    public List<RequestReadDTO> GetAll();
    public RequestReadDTO? GetByID(Guid id);
    public void Add(RequestCostemerProviderWriteDTO Request);
    public bool Update(RequestProviderCustomerWriteDTO Request);
    public bool UpdateState(RequestUpdateStateWriteDTO Request);
    public List<RequestReadDTO> GetCustomerRequests(string CustomerId);
    public List<RequestReadDTO> GetProviderRequests(string ProviderId);
    public void Delete(Guid id);
}
