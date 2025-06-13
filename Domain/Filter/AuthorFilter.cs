namespace Domain.Filter;

public class AuthorFilter : ValidFilter
{
      public string? Title { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}
