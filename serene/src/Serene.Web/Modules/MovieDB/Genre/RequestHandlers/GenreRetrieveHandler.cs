using MyRow = Serene.MovieDB.GenreRow;

namespace Serene.MovieDB;

/// <summary>
/// Loads one genre by id for the edit dialog. Empty on purpose.
/// </summary>
public interface IGenreRetrieveHandler : IRetrieveHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class GenreRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IGenreRetrieveHandler
{
}
