namespace Serene.MovieDB.Pages;

/// <summary>
/// Serves the Genres screen; the grid in GenrePage.tsx fetches its rows from the endpoint.
/// </summary>
[PageAuthorize(typeof(GenreRow))]
public class GenrePage : Controller
{
    [Route("MovieDB/Genre")]
    public ActionResult Index()
    {
        return this.GridPage<GenreRow>("@/MovieDB/Genre/GenrePage");
    }
}
