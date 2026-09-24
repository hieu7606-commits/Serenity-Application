namespace Serene.MovieDB.Columns;

/// <summary>
/// The Genres grid's columns, and the Excel export's.
/// </summary>
[ColumnsScript("MovieDB.Genre")]
[BasedOnRow(typeof(GenreRow), CheckNames = true)]
public class GenreColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int? GenreId { get; set; }
    [EditLink]
    public string? Name { get; set; }
}
