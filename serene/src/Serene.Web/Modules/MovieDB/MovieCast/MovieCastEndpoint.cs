using System.Data;
using MyRow = Serene.MovieDB.MovieCastRow;

namespace Serene.MovieDB.Endpoints;

/// <summary>
/// The service methods for MovieCast, at Services/MovieDB/MovieCast/{action}. The movie dialog
/// does not call these - cast is saved together with the movie - but they are there for code or
/// tools that need to work with cast entries directly.
/// </summary>
[Route("Services/MovieDB/MovieCast/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class MovieCastEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public Task<SaveResponse> Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IMovieCastSaveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.CreateAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public Task<SaveResponse> Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IMovieCastSaveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.UpdateAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public Task<DeleteResponse> Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IMovieCastDeleteHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.DeleteAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public Task<RetrieveResponse<MyRow>> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IMovieCastRetrieveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.RetrieveAsync(connection, request, cancellationToken);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public Task<ListResponse<MyRow>> List(IDbConnection connection, ListRequest request,
        [FromServices] IMovieCastListHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.ListAsync(connection, request, cancellationToken);
    }
}
