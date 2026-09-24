using MyRow = Serene.MovieDB.MovieGenresRow;

namespace Serene.MovieDB;

/// <summary>
/// Lists movie/genre pairs. Empty on purpose.
/// </summary>
public interface IMovieGenresListHandler : IListHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>> { }

public class MovieGenresListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IMovieGenresListHandler
{
}
