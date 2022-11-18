using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class AutoMapperProfile :Profile
{
    public AutoMapperProfile()
    {
        #region AuthMapper
        CreateMap<UserSignUp, CustomeUser>();
        CreateMap<SignUpCustomer, UserSignUp>();
        CreateMap<SignUpProvider, UserSignUp>();
        #endregion

        CreateMap<Category,CategoryReadDTO>();
        CreateMap<CategoryWriteDTO, Category>();

        CreateMap<Customer, CustomerReadDTO>();
        CreateMap<CustomerWriteDTO, Customer>();

        CreateMap<Media, MediaReadDTO>();
        CreateMap<MediaWriteDTO, Media>();

        CreateMap<Post, PostReadDTO>();
        CreateMap<PostWriteDTO, Post>();

        CreateMap<Provider, ProviderReadDTO>();
        CreateMap<ProviderWriteDTO, Provider>();

        CreateMap<Request, RequestReadDTO>();
        CreateMap<RequestWriteDTO, Request>();
        CreateMap<RequestCostemerProviderWriteDTO, Request>();
        CreateMap<RequestProviderCustomerWriteDTO, Request>();
        
        CreateMap <RequestmessageWriteDTO, RequestUpdateStateWriteDTO>();

        CreateMap<Service, ServiceReadDTO>();
        CreateMap<ServiceWriteDTO, Service>();

        CreateMap<Provider, ProviderUserReadDTO>();

        CreateMap<Post, MediasforPost>();

        
    }
}
