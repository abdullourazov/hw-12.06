using AutoMapper;
using Domain.DTOs.AuthorDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Author, GetAuthorDTO>().ReverseMap();
        CreateMap<Author, CreateAuthorDTO>().ReverseMap();
        CreateMap<Author, UpdateAuthorDTO>().ReverseMap();
    }
}
