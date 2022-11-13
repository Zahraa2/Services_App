using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region AuthMapper
            CreateMap<UserSignUp, CustomeUser>();
            CreateMap<SignUpCustomer, UserSignUp>();
            CreateMap<SignUpProvider, UserSignUp>();
            #endregion
        }
    }
}
