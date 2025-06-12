using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Editor
{
    [Key]
    public int EditorId { get; set; }

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
    public string EditorPosition { get; set; }
    public decimal Salary { get; set; }

    public List<BookEditor> BookEditors { get; set; }


}
