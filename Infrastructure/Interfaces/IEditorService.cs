using Domain.ApiResponse;
using Domain.DTOs.EditorDTOs;
using Domain.Filter;

namespace Infrastructure.Interfaces;

public interface IEditorService
{
    Task<Response<string>> CreateEditorAsync(CreateEditorDTO createEditorDTO);
    Task<PagedResponse<List<GetEditorDTO>>> GetEditorAsync(EditorFilter filter);
    Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDTO updateEditorDTO);
    Task<Response<string>> DeleteEditorAsync(int id);
}
