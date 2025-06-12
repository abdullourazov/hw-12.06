namespace Domain.DTOs.BookAuthorDTOs;

public class CreateBookAuthorDTO
{
    public string Isbn { get; set; }

    public int AuthorId { get; set; }
    public int AuthorOrder { get; set; }
    public decimal Royaltyshare { get; set; }
}
