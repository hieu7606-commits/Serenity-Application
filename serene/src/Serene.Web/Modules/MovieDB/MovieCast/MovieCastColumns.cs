namespace Serene.MovieDB.Columns;

/// <summary>
/// The cast grid's columns inside the movie dialog. MovieRow.CastList's MasterDetailRelation also
/// names this class, so every field listed here - including PersonFullName, which comes through a
/// join - is loaded when a movie is opened.
/// </summary>
[ColumnsScript("MovieDB.MovieCast")]
[BasedOnRow(typeof(MovieCastRow), CheckNames = true)]
public class MovieCastColumns
{
    [EditLink, Width(250)]
    public string? PersonFullName { get; set; }
    [EditLink, Width(250)]
    public string? Character { get; set; }
}
