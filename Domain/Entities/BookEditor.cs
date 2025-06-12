namespace Domain.Entities;

public class BookEditor
{
    public string Isbn { get; set; }
    public int EditorId { get; set; }

    public Book Book { get; set; }
    public Editor Editor { get; set; }
}
