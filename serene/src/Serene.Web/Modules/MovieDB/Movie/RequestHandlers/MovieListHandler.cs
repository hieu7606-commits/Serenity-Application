using MyRow = Serene.MovieDB.MovieRow;

namespace Serene.MovieDB;

/// <summary>
/// Serves the grid: paging, sorting, the quick search box and any filters the user applied all
/// arrive in the ListRequest and are turned into one SELECT. The Excel export runs through here
/// too, so a restriction added here applies to the download as well.
/// </summary>
/// <remarks>
/// Empty on purpose - the base class does the query. Override <c>ApplyFilters</c> to limit what a
/// user may see (their own records, an active flag), or <c>PrepareQuery</c> to join another table.
/// </remarks>
public interface IMovieListHandler : IListHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>> { }

public class MovieListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IMovieListHandler
{
}