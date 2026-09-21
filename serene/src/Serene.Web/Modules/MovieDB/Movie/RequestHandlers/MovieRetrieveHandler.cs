using MyRow = Serene.MovieDB.MovieRow;

namespace Serene.MovieDB;

/// <summary>
/// Loads one movie by id - what the edit dialog calls when a row is opened. The grid already has
/// the values on screen, but the dialog re-reads the record so it edits what is currently stored
/// rather than what the list happened to fetch earlier.
/// </summary>
/// <remarks>
/// Empty on purpose. Override <c>PrepareQuery</c> to bring in fields the list does not need, or
/// <c>OnReturn</c> to shape the record before it reaches the client.
/// </remarks>
public interface IMovieRetrieveHandler : IRetrieveHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class MovieRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IMovieRetrieveHandler
{
}