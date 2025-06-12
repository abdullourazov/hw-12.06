using Domain.Entities;
using Domain.ApiResponse;
using Domain.DTOs.AuthorDTOs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs.AuthorDTOs;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthorController(IAuthorService authorService)
{
    [HttpGet]
    public async Task<Response<List<GetAuthorDTO>>> GetAuthorAsync(int id)
    {
        return await authorService.GetAuthorAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO)
    {
        return await authorService.CreateAuthorAsync(createAuthorDTO);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAuthorAsync(int id, UpdateAuthorDTO updateAuthorDTO)
    {
        return await authorService.UpdateAuthorAsync(id, updateAuthorDTO);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        return await authorService.DeleteAuthorAsync(id);
    }
}
