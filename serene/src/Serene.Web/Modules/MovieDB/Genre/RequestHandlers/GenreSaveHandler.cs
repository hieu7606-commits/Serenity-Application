using MyRow = Serene.MovieDB.GenreRow;

namespace Serene.MovieDB;

/// <summary>
/// Create and update for Genre. Empty on purpose - see <see cref="MovieSaveHandler"/> for where to
/// override.
/// </summary>
public interface IGenreSaveHandler : ISaveHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class GenreSaveHandler(IRequestContext context) :
    SaveRequestHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IGenreSaveHandler
{
}
