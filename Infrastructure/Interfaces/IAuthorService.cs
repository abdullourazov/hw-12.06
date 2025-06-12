using Domain.ApiResponse;
using Domain.DTOs.AuthorDTOs;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
    Task<Response<List<GetAuthorDTO>>> GetAuthorAsync(int id);
    Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO);
    Task<Response<string>> DeleteAuthorAsync(int id);
}
