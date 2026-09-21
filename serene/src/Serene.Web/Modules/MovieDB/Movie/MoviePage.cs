namespace Serene.MovieDB.Pages;

/// <summary>
/// Serves the Movie screen itself - the HTML shell the browser lands on. It carries no data: the
/// page renders an empty grid, which then calls <see cref="Endpoints.MovieEndpoint"/> for rows.
/// </summary>
// PageAuthorize(typeof(MovieRow)): the row's ReadPermission guards the page, so a user without it
// is turned away here rather than seeing an empty grid that fails on every request.
[PageAuthorize(typeof(MovieRow))]
public class MoviePage : Controller
{
    // The URL users visit, and what MovieDBNavigation.cs points the sidebar entry at.
    [Route("MovieDB/Movie")]
    public ActionResult Index()
    {
        // GridPage renders the shared grid layout and points it at the module entry below. The "@/"
        // path is resolved to the built MoviePage.tsx bundle, which boots MovieGrid in the browser.
        return this.GridPage<MovieRow>("@/MovieDB/Movie/MoviePage");
    }
}