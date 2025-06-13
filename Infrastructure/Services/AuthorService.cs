using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.AuthorDTOs;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService(DataContext context, IMapper mapper) : IAuthorService
{
    public async Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO)
    {
        var mapped = mapper.Map<Author>(createAuthorDTO);
        var result = await context.Authors.AddAsync(mapped);
        await context.SaveChangesAsync();
        return result == null
     ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
     : new Response<string>(null, "Done succesfully");

    }

    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        var aut = await context.Authors.FindAsync(id);
        if (aut == null)
        {
            return new Response<string>("Author not found", HttpStatusCode.NotFound);
        }

        context.Authors.Remove(aut);
        var res = await context.SaveChangesAsync();

        return res == null
        ? new Response<string>("Somethink went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done Succesfully");
    }


    public async Task<PagedResponse<List<GetAuthorDTO>>> GetAuthorAsync(AuthorFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);
        var query = context.Authors.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(p => p.FirstName.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        var totalRecords = await query.CountAsync();

        var paged = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();

        var mapped = mapper.Map<List<GetAuthorDTO>>(paged);

        return new PagedResponse<List<GetAuthorDTO>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO)
    {
        var foundAuthor = await context.Authors.FindAsync(id);
        if (foundAuthor == null)
        {
            return new Response<string>("Author not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<Author>(updateAuthorDTO);
        var result = await context.SaveChangesAsync();

        return result == null
        ? new Response<string>("Something went wrong", HttpStatusCode.NotFound)
        : new Response<string>(null, "Done succesfully");
    }

}
