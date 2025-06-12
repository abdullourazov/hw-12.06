using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BookAuthor
{
    public string Isbn { get; set; }

    public int AuthorId { get; set; }
    public int AuthorOrder { get; set; }
    public decimal Royaltyshare { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }

}
