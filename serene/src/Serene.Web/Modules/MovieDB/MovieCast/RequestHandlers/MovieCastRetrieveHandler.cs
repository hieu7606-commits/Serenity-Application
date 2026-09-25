using MyRow = Serene.MovieDB.MovieCastRow;

namespace Serene.MovieDB;

/// <summary>
/// Loads one cast entry by id. Empty on purpose.
/// </summary>
public interface IMovieCastRetrieveHandler : IRetrieveHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class MovieCastRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IMovieCastRetrieveHandler
{
}
