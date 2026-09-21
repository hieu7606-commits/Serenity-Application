using MyRow = Serene.MovieDB.MovieRow;

namespace Serene.MovieDB;

/// <summary>
/// Deletes one movie by id. Movie has no IsActive or IsDeleted column, so this is a real DELETE -
/// add one of those fields to the row and the base handler marks the record instead of removing it.
/// </summary>
/// <remarks>
/// Empty on purpose. Override <c>ValidateRequest</c> to refuse a delete that would break something
/// - a movie still referenced elsewhere - or <c>OnBeforeDelete</c> to clear dependent rows first,
/// which runs inside the same transaction as the delete.
/// </remarks>
public interface IMovieDeleteHandler : IDeleteHandlerAsync<MyRow, DeleteRequest, DeleteResponse> { }

public class MovieDeleteHandler(IRequestContext context) :
    DeleteRequestHandlerAsync<MyRow, DeleteRequest, DeleteResponse>(context),
    IMovieDeleteHandler
{
}