using MyRow = Serene.MovieDB.PersonRow;

namespace Serene.MovieDB;

/// <summary>
/// Create and update for Person. Empty on purpose - see <see cref="MovieSaveHandler"/> for where
/// to override.
/// </summary>
public interface IPersonSaveHandler : ISaveHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class PersonSaveHandler(IRequestContext context) :
    SaveRequestHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IPersonSaveHandler
{
}
