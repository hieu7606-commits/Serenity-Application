using MyRow = Serene.MovieDB.MovieCastRow;

namespace Serene.MovieDB;

/// <summary>
/// Lists cast entries. Empty on purpose.
/// </summary>
public interface IMovieCastListHandler : IListHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>> { }

public class MovieCastListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IMovieCastListHandler
{
}
