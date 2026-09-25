using MyRow = Serene.MovieDB.MovieCastRow;

namespace Serene.MovieDB;

/// <summary>
/// Create and update for one cast entry. MasterDetailRelation on MovieRow.CastList calls this for
/// each new or changed entry when a movie is saved, so logic added here applies there too.
/// </summary>
public interface IMovieCastSaveHandler : ISaveHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class MovieCastSaveHandler(IRequestContext context) :
    SaveRequestHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IMovieCastSaveHandler
{
}
