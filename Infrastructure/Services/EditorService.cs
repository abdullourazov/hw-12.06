using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.EditorDTOs;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EditorService(DataContext context, IMapper mapper) : IEditorService
{
    public async Task<Response<string>> CreateEditorAsync(CreateEditorDTO createEditorDTO)
    {
        var mapped = mapper.Map<Editor>(createEditorDTO);
        var result = await context.Editors.AddAsync(mapped);
        await context.SaveChangesAsync();
        return result == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }




    public async Task<Response<string>> DeleteEditorAsync(int id)
    {
        var Editor = await context.Editors.FindAsync(id);
        if (Editor == null)
        {
            return new Response<string>("Editor not found", HttpStatusCode.NotFound);
        }

        context.Editors.Remove(Editor);
        var result = await context.SaveChangesAsync();
        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }




    public async Task<PagedResponse<List<GetEditorDTO>>> GetEditorAsync(EditorFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);
        var query = context.Editors.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(p => p.FirstName.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        var totalRecords = await query.CountAsync();


        var paged = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();

        var mapped = mapper.Map<List<GetEditorDTO>>(paged);

        return new PagedResponse<List<GetEditorDTO>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public Task<Response<string>> UpdateEditorAsync(int id, UpdateEditorDTO updateEditorDTO)
    {
        throw new NotImplementedException();
    }


    public async Task<Response<string>> UpdatePublishAsync(int id, UpdateEditorDTO updateEditorDTO)
    {
        var foundEditor = await context.Editors.FindAsync(id);
        if (foundEditor == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<Book>(updateEditorDTO);
        var result = await context.SaveChangesAsync();

        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }
}
