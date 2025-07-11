using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.PublisherDTOs;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PublisherService(DataContext context, IMapper mapper) : IPublisherService
{
    public async Task<Response<string>> CreatePublishAsync(CreatePublisherDTO createPublisherDTO)
    {
        var mapped = mapper.Map<Publisher>(createPublisherDTO);
        var result = await context.Publishers.AddAsync(mapped);
        await context.SaveChangesAsync();
        return result == null
        ? new Response<string>("Something went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }

    public async Task<Response<string>> DeletePublishAsync(int id)
    {
        var publisher = await context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return new Response<string>("Publisher not found", HttpStatusCode.NotFound);
        }

        context.Publishers.Remove(publisher);
        var result = await context.SaveChangesAsync();
        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }


    public async Task<PagedResponse<List<GetPublisherDTO>>> GetPublisherAsync(PublisherFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);
        var query = context.Publishers.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(p => p.Name.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        var totalRecords = await query.CountAsync();


        var paged = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();

        var mapped = mapper.Map<List<GetPublisherDTO>>(paged);

        return new PagedResponse<List<GetPublisherDTO>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Response<string>> UpdatePublishAsync(int id, UpdatePublisherDTO updatePublisherDTO)
    {
        var foundPublisher = await context.Publishers.FindAsync(id);
        if (foundPublisher == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<Book>(updatePublisherDTO);
        var result = await context.SaveChangesAsync();

        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }

}
