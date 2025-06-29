using AutoMapper;
using Banking.Application.DTOs.Common;
using Banking.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Mappings;

public class BaseMappingProfile : Profile
{
    public BaseMappingProfile()
    {
        CreateMap<BaseEntity, BaseEntityDto>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => !src.IsDeleted));
    }
}
