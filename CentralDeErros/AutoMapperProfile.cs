using AutoMapper;
using CentralDeErros.Api.DTO;
using CentralDeErros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Log, LogDTO>().ReverseMap();
        }
    }
}
