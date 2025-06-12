using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.AuthorDTOs;

public class CreateAuthorDTO
{
    [Key]
    public int AuthourId { get; set; }

    [Required]
    [MaxLength(11)]
    public string SSN { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    [MaxLength(100)]
    public string Address { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(20)]
    public string State { get; set; }

    [MaxLength(10)]
    public string Zip { get; set; }
}
