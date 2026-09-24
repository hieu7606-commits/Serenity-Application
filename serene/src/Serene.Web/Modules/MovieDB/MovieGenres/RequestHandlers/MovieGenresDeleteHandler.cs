using MyRow = Serene.MovieDB.MovieGenresRow;

namespace Serene.MovieDB;

/// <summary>
/// Deletes one movie/genre pair by id. Empty on purpose.
/// </summary>
public interface IMovieGenresDeleteHandler : IDeleteHandlerAsync<MyRow, DeleteRequest, DeleteResponse> { }

public class MovieGenresDeleteHandler(IRequestContext context) :
    DeleteRequestHandlerAsync<MyRow, DeleteRequest, DeleteResponse>(context),
    IMovieGenresDeleteHandler
{
}
