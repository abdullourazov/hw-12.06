using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.BookDTOs;

public class CreateBookDTO
{
    [Required]
    [MaxLength(17)]
    public string Isbn { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(50)]
    public string Type { get; set; }
    public int PublishedId { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public int Ytdsales { get; set; }
    public DateTime PubDate { get; set; }
}
