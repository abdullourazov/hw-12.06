using Domain.ApiResponse;
using Domain.DTOs.PublisherDTOs;
using Domain.Filter;

namespace Infrastructure.Interfaces;

public interface IPublisherService
{
    Task<Response<string>> CreatePublishAsync(CreatePublisherDTO createPublisherDTO);
    Task<PagedResponse<List<GetPublisherDTO>>> GetPublisherAsync(PublisherFilter filter);
    Task<Response<string>> UpdatePublishAsync(int id, UpdatePublisherDTO updatePublisherDTO);
    Task<Response<string>> DeletePublishAsync(int id);
}
