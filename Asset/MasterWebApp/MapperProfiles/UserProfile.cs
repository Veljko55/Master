using MasterWebApp.Models.User;
using SqlDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace MasterWebApp.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserCookieData>()
                .ReverseMap();
        }
    }
}