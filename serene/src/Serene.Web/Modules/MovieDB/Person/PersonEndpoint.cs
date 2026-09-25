using Serenity.Reporting;
using System.Data;
using System.Globalization;
using MyRow = Serene.MovieDB.PersonRow;

namespace Serene.MovieDB.Endpoints;

/// <summary>
/// The service methods for Person, at Services/MovieDB/Person/{action}. Thin on purpose, like
/// <see cref="MovieEndpoint"/>: permission checks here, behaviour in the request handlers.
/// </summary>
[Route("Services/MovieDB/Person/[action]")]
[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
public class PersonEndpoint : ServiceEndpoint
{
    [HttpPost, AuthorizeCreate(typeof(MyRow))]
    public Task<SaveResponse> Create(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IPersonSaveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.CreateAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeUpdate(typeof(MyRow))]
    public Task<SaveResponse> Update(IUnitOfWork uow, SaveRequest<MyRow> request,
        [FromServices] IPersonSaveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.UpdateAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeDelete(typeof(MyRow))]
    public Task<DeleteResponse> Delete(IUnitOfWork uow, DeleteRequest request,
        [FromServices] IPersonDeleteHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.DeleteAsync(uow, request, cancellationToken);
    }

    [HttpPost, AuthorizeRetrieve(typeof(MyRow))]
    public Task<RetrieveResponse<MyRow>> Retrieve(IDbConnection connection, RetrieveRequest request,
        [FromServices] IPersonRetrieveHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.RetrieveAsync(connection, request, cancellationToken);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public Task<ListResponse<MyRow>> List(IDbConnection connection, ListRequest request,
        [FromServices] IPersonListHandler handler, CancellationToken cancellationToken = default)
    {
        return handler.ListAsync(connection, request, cancellationToken);
    }

    [HttpPost, AuthorizeList(typeof(MyRow))]
    public async Task<FileContentResult> ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IPersonListHandler handler,
        [FromServices] IExcelExporter exporter, CancellationToken cancellationToken = default)
    {
        var data = (await List(connection, request, handler, cancellationToken)).Entities;
        var bytes = exporter.Export(data, typeof(Columns.PersonColumns), request.ExportColumns);
        return ExcelContentResult.Create(bytes, "PersonList_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
    }
}
