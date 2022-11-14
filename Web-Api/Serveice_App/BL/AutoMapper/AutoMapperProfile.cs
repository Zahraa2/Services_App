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

        CreateMap<Service, ServiceReadDTO>();
        CreateMap<ServiceWriteDTO, Service>();

        CreateMap<Provider, ProviderUserReadDTO>();
    }
}
