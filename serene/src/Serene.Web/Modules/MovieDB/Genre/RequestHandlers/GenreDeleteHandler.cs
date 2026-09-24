using MyRow = Serene.MovieDB.GenreRow;

namespace Serene.MovieDB;

/// <summary>
/// Deletes one genre by id. A genre still used by a movie is refused by the FK_MovieGenres_GenreId
/// foreign key; override <c>ValidateRequest</c> to report that with a friendlier message.
/// </summary>
public interface IGenreDeleteHandler : IDeleteHandlerAsync<MyRow, DeleteRequest, DeleteResponse> { }

public class GenreDeleteHandler(IRequestContext context) :
    DeleteRequestHandlerAsync<MyRow, DeleteRequest, DeleteResponse>(context),
    IGenreDeleteHandler
{
}
