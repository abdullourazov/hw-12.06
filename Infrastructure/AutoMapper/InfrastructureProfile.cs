using AutoMapper;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.BookDTOs;
using Domain.DTOs.EditorDTOs;
using Domain.DTOs.PublisherDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Author, GetAuthorDTO>().ReverseMap();
        CreateMap<Author, CreateAuthorDTO>().ReverseMap();
        CreateMap<Author, UpdateAuthorDTO>().ReverseMap();

        CreateMap<Book, GetBookDTO>().ReverseMap();
        CreateMap<Book, CreateBookDTO>().ReverseMap();
        CreateMap<Book, UpdateBookDTO>().ReverseMap();

        CreateMap<Editor, GetEditorDTO>().ReverseMap();
        CreateMap<Editor, CreateEditorDTO>().ReverseMap();
        CreateMap<Editor, UpdateEditorDTO>().ReverseMap();

        CreateMap<Publisher, GetPublisherDTO>().ReverseMap();
        CreateMap<Publisher, CreatePublisherDTO>().ReverseMap();
        CreateMap<Publisher, UpdatePublisherDTO>().ReverseMap();
    }
}
