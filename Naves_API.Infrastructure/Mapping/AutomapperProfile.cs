using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Naves_API.Core.DTOs;
using Naves_API.Core.Entities;

namespace Naves_API.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Nave, NaveDto>();
            CreateMap<NaveDto, Nave>();
        }
    }
}
