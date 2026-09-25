namespace Serene.MovieDB.Forms;

/// <summary>
/// The layout of MovieCastEditDialog, opened from the cast grid inside the movie dialog. MovieId
/// is left out on purpose: a cast entry always belongs to the movie being edited, so offering it
/// would only allow adding Neo to the wrong film.
/// </summary>
[FormScript("MovieDB.MovieCast")]
[BasedOnRow(typeof(MovieCastRow), CheckNames = true)]
public class MovieCastForm
{
    public int? PersonId { get; set; }
    public string? Character { get; set; }
}
