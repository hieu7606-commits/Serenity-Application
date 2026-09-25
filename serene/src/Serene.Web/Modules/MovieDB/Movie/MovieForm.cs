namespace Serene.MovieDB.Forms;

/// <summary>
/// The edit dialog's layout: which fields appear, and in what order. Reorder the properties and the
/// dialog reorders with them; remove one and it is no longer editable through the dialog.
/// </summary>
/// <remarks>
/// Most editor types and captions are not declared here because <see cref="BasedOnRowAttribute"/> takes them
/// from the matching property on <see cref="MovieRow"/> - a DateTime becomes a date picker, Size
/// and NotNull become the input's length and required mark. Declare an attribute here only to
/// override what the row already says.
///
/// MovieId is deliberately absent: it is an identity column the database assigns.
/// </remarks>
// FormScript: publishes this layout to the client under "MovieDB.Movie", which is the key
// MovieDialog asks for through the generated MovieForm.formKey.
[FormScript("MovieDB.Movie")]
// CheckNames: a property whose name no longer matches the row fails the build rather than silently
// disappearing from the dialog - worth keeping when the table changes.
[BasedOnRow(typeof(MovieRow), CheckNames = true)]
public class MovieForm
{
    public string? Title { get; set; }
    // Free text reads better in a multi-line box than the single-line input a string implies.
    [TextAreaEditor(Rows = 3)]
    public string? Description { get; set; }
    // MovieCastEditor is the cast grid (MovieCastEditor.tsx); sergen generates this attribute from
    // it. SkipNameCheck is left over from before CastList existed on MovieRow - harmless now, and
    // kept to match the tutorial.
    [DisplayName("Cast"), MovieCastEditor, SkipNameCheck]
    public List<MovieCastRow>? CastList { get; set; }
    [TextAreaEditor(Rows = 8)]
    public string? Storyline { get; set; }
    public int? Year { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Runtime { get; set; }
    public MovieKind? Kind { get; set; }
    public List<int>? GenreList { get; set; }
}