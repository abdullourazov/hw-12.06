using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.AuthorDTOs;
using Domain.Entities;
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

    public async Task<Response<List<GetAuthorDTO>>> GetAuthorAsync(int id)
    {
        var aut = await context.Authors.FindAsync(id);
        if (aut == null)
        {
            return new Response<List<GetAuthorDTO>>("Author not found", HttpStatusCode.NotFound);
        }
        var mapped = mapper.Map<List<GetAuthorDTO>>(aut);

        return mapped == null
        ? new Response<List<GetAuthorDTO>>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<List<GetAuthorDTO>>(mapped, "Done Succesfully");
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
