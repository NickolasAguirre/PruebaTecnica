using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class AutomapperConfiguration:Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<UserUpdateorCreateCommand, LibeyUser>();
           
        }
    }
}
