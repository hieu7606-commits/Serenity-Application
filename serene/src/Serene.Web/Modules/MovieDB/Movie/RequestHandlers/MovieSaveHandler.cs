using MyRow = Serene.MovieDB.MovieRow;

namespace Serene.MovieDB;

/// <summary>
/// Handles both create and update for Movie - a save with no id inserts, one with an id updates.
/// This is where saving behaviour belongs: validation beyond the row's own attributes, defaults,
/// audit fields, or anything that has to happen in the same transaction as the write.
/// </summary>
/// <remarks>
/// Empty on purpose. The base class already does the whole save, so the class exists to give you
/// somewhere to override - <c>ValidateRequest</c>, <c>SetInternalFields</c>, <c>BeforeSave</c> and
/// <c>AfterSave</c> are the usual places to start.
///
/// The interface is what <see cref="Endpoints.MovieEndpoint"/> asks the container for, so swapping
/// in a different implementation is a registration change rather than an edit to the endpoint.
/// </remarks>
public interface IMovieSaveHandler : ISaveHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class MovieSaveHandler(IRequestContext context) :
    SaveRequestHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IMovieSaveHandler
{
}