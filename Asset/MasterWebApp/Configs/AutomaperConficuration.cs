using AutoMapper;
using MasterWebApp.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterWebApp.Configs
{
    public static class AutomaperConficuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });
        }
    }
}