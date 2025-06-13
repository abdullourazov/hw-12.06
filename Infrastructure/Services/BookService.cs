using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.BookDTOs;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService(DataContext context, IMapper mapper) : IBookService
{
    public async Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO)
    {
        var mapped = mapper.Map<Book>(createBookDTO);
        var result = await context.Books.AddAsync(mapped);
        await context.SaveChangesAsync();
        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }
        context.Books.Remove(book);
        var res = await context.SaveChangesAsync();
        return res == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }

    public async Task<PagedResponse<List<GetBookDTO>>> GetBookAsync(BookFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);
        var query = context.Books.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(b => b.Title.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        if (filter.MinPrice != null)
        {
            query = query.Where(b => b.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice != null)
        {
            query = query.Where(b => b.Price >= filter.MaxPrice);
        }

        var totalRecords = await query.CountAsync();

        var paged = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();

        var mapped = mapper.Map<List<GetBookDTO>>(paged);

        return new PagedResponse<List<GetBookDTO>>(mapped, totalRecords, validFilter.PageNumber, validFilter.PageSize);

    }

 


    public async Task<Response<string>> UpdateBookAsync(int id, UpdateBookDTO updateBookDTO)
    {
        var foundBook = await context.Books.FindAsync(id);
        if (foundBook == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<Book>(updateBookDTO);
        var result = await context.SaveChangesAsync();

        return result == null
        ? new Response<string>("Someting went wrong", HttpStatusCode.InternalServerError)
        : new Response<string>(null, "Done succesfully");
    }

}
