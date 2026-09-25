using MyRow = Serene.MovieDB.PersonRow;

namespace Serene.MovieDB;

/// <summary>
/// Loads one person by id for the edit dialog. Empty on purpose.
/// </summary>
public interface IPersonRetrieveHandler : IRetrieveHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>> { }

public class PersonRetrieveHandler(IRequestContext context) :
    RetrieveRequestHandlerAsync<MyRow, RetrieveRequest, RetrieveResponse<MyRow>>(context),
    IPersonRetrieveHandler
{
}
