using MyRow = Serene.MovieDB.GenreRow;

namespace Serene.MovieDB;

/// <summary>
/// Serves the Genres grid and its Excel export. Empty on purpose - the base class does the query.
/// </summary>
public interface IGenreListHandler : IListHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>> { }

public class GenreListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IGenreListHandler
{
}
