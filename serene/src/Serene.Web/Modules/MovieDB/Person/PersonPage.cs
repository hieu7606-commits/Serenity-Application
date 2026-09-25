namespace Serene.MovieDB.Pages;

/// <summary>
/// Serves the Person screen; the grid in PersonPage.tsx fetches its rows from the endpoint.
/// </summary>
[PageAuthorize(typeof(PersonRow))]
public class PersonPage : Controller
{
    [Route("MovieDB/Person")]
    public ActionResult Index()
    {
        return this.GridPage<PersonRow>("@/MovieDB/Person/PersonPage");
    }
}
