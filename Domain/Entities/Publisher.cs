using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Publisher
{
    [Key]
    public int PublisherId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Address { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(20)]
    public string State { get; set; }

    public List<Book> Books { get; set; }
}
