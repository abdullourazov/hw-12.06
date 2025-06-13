using Domain.ApiResponse;
using Domain.DTOs.BookDTOs;
using Domain.Filter;

namespace Infrastructure.Interfaces;

public interface IBookService
{
    Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO);
    Task<PagedResponse<List<GetBookDTO>>> GetBookAsync(BookFilter filter);
    Task<Response<string>> UpdateBookAsync(int id, UpdateBookDTO updateBookDTO);
    Task<Response<string>> DeleteBookAsync(int id);
}
