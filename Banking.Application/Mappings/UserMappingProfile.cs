using AutoMapper;
using Banking.Application.DTOs.Commands.CreateUser;
using Banking.Application.DTOs.Queries.GetByUserId;
using Banking.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // User Entity -> CreateUserResponse
        CreateMap<User, CreateUserResponse>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive && !src.IsDeleted));

        // User Entity -> GetUserByIdResponse
        CreateMap<User, GetUserByIdResponse>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive && !src.IsDeleted));

        // CreateUserCommand -> User Entity
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.LastLoginAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
    }
}
