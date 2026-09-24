using MyRow = Serene.MovieDB.MovieGenresRow;

namespace Serene.MovieDB;

/// <summary>
/// Loads one movie/genre pair by id. Empty on purpose.
/// </summary>
public interface IMovieGenresRetrieveHandler : IRetrieveHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class MovieGenresRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IMovieGenresRetrieveHandler
{
}
