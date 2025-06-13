using Domain.ApiResponse;
using Domain.DTOs.AuthorDTOs;
using Domain.Filter;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
    Task<PagedResponse<List<GetAuthorDTO>>> GetAuthorAsync(AuthorFilter filter);
    Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO);
    Task<Response<string>> DeleteAuthorAsync(int id);
}
