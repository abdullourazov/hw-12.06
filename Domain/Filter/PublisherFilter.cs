namespace Domain.Filter;

public class PublisherFilter : ValidFilter
{
    public string? Title { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}
