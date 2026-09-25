using MyRow = Serene.MovieDB.PersonRow;

namespace Serene.MovieDB;

/// <summary>
/// Serves the Person grid and its Excel export. Empty on purpose - the base class does the query.
/// </summary>
public interface IPersonListHandler : IListHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>> { }

public class PersonListHandler(IRequestContext context) :
    ListRequestHandlerAsync<MyRow, ListRequest, ListResponse<MyRow>>(context),
    IPersonListHandler
{
}
