using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Book
{
    [Key]
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

    public int Publisherid { get; set; }
    public Publisher Publisher { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public List<BookAuthor> BookAuthors { get; set; }
    public List<BookEditor> BookEditors { get; set; }
}
