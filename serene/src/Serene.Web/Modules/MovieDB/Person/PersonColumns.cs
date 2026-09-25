namespace Serene.MovieDB.Columns;

/// <summary>
/// The Person grid's columns, and the Excel export's.
/// </summary>
[ColumnsScript("MovieDB.Person")]
[BasedOnRow(typeof(PersonRow), CheckNames = true)]
public class PersonColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int? PersonId { get; set; }
    [EditLink]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthPlace { get; set; }
    public Gender? Gender { get; set; }
    public int? Height { get; set; }
}
