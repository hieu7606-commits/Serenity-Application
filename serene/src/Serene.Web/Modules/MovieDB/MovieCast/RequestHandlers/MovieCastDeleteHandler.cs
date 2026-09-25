using MyRow = Serene.MovieDB.MovieCastRow;

namespace Serene.MovieDB;

/// <summary>
/// Deletes one cast entry. MasterDetailRelation calls this for entries removed from a movie's cast
/// list, and for all of them when the movie itself is deleted.
/// </summary>
public interface IMovieCastDeleteHandler : IDeleteHandlerAsync<MyRow, DeleteRequest, DeleteResponse> { }

public class MovieCastDeleteHandler(IRequestContext context) :
    DeleteRequestHandlerAsync<MyRow, DeleteRequest, DeleteResponse>(context),
    IMovieCastDeleteHandler
{
}
