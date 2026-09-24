namespace Serene.MovieDB.Forms;

/// <summary>
/// The Genre dialog's layout. The same dialog opens from the Genres page and from the in-place add
/// button on the movie form's Genre dropdown.
/// </summary>
[FormScript("MovieDB.Genre")]
[BasedOnRow(typeof(GenreRow), CheckNames = true)]
public class GenreForm
{
    public string? Name { get; set; }
}
