namespace Serene.MovieDB.Columns;

/// <summary>
/// The grid's columns: which ones appear, in what order, and how each is rendered. It is also what
/// the Excel export is built from, so a column dropped here leaves the spreadsheet too.
/// </summary>
/// <remarks>
/// Captions and formats come from <see cref="MovieRow"/> through
/// <see cref="BasedOnRowAttribute"/>; declare an attribute here only to override the row.
///
/// Listing a column does not by itself fetch it - the list service returns the row's fields, and
/// the grid shows the ones named here.
/// </remarks>
// ColumnsScript: publishes this list to the client under "MovieDB.Movie", the key MovieGrid asks
// for through the generated MovieColumns.columnsKey. Forms and columns may share a key; they are
// separate registries.
[ColumnsScript("MovieDB.Movie")]
[BasedOnRow(typeof(MovieRow), CheckNames = true)]
public class MovieColumns
{
    // EditLink turns the cell into a link that opens the edit dialog. It is on two columns so the
    // row can be opened from either the id or the title; drop it from one if that reads better.
    // The DisplayName here is a translation key, not literal text - see the Db.Shared entries in
    // the local text resources.
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int? MovieId { get; set; }
    [EditLink]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Storyline { get; set; }
    public int? Year { get; set; }
    public DateTime? ReleaseDate { get; set; }
    [DisplayName("Runtime in Minutes"), Width(150), AlignRight]
    public int? Runtime { get; set; }
    // QuickFilter on the name column still filters by GenreId - Serenity follows the join back to
    // it and reuses its lookup editor for the filter dropdown.
    [Width(100), QuickFilter]
    public string? GenreName { get; set; }
    public MovieKind? Kind { get; set; }
}