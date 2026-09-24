using MyRequest = Serene.MovieDB.MovieListRequest;
using MyRow = Serene.MovieDB.MovieRow;

namespace Serene.MovieDB;

/// <summary>
/// Serves the grid: paging, sorting, the quick search box and any filters the user applied all
/// arrive in the MovieListRequest and are turned into one SELECT. The Excel export runs through
/// here too, so a restriction added here applies to the download as well.
/// </summary>
/// <remarks>
/// The base class does the query; the one override below adds the Genres filter. Override
/// <c>PrepareQuery</c> to join another table.
/// </remarks>
public interface IMovieListHandler : IListHandlerAsync<MyRow, MyRequest, ListResponse<MyRow>> { }

public class MovieListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, MyRequest, ListResponse<MyRow>>(context),
    IMovieListHandler
{
    // Keeps movies having at least one of the requested genres:
    //   WHERE EXISTS (SELECT 1 FROM MovieGenres mg
    //                 WHERE mg.MovieId = t0.MovieId AND mg.GenreId IN (...))
    // The "mg" alias matters: MovieRow's fields already use t0, and an unaliased MovieGenresRow
    // would claim t0 as well.
    protected override async Task ApplyFiltersAsync(SqlQuery query,
        CancellationToken cancellationToken = default)
    {
        await base.ApplyFiltersAsync(query, cancellationToken);

        if (!Request.Genres.IsEmptyOrNull())
        {
            var fld = MyRow.Fields;
            var mg = MovieGenresRow.Fields.As("mg");

            query.Where(Criteria.Exists(
                query.SubQuery()
                    .From(mg)
                    .Select("1")
                    .Where(
                        mg.MovieId == fld.MovieId &&
                        mg.GenreId.In(Request.Genres))));
        }
    }
}
