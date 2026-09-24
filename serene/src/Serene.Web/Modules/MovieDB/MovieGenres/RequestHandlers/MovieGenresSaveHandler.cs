using MyRow = Serene.MovieDB.MovieGenresRow;

namespace Serene.MovieDB;

/// <summary>
/// Create and update for a single movie/genre pair. Empty on purpose.
/// </summary>
public interface IMovieGenresSaveHandler : ISaveHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse> { }

public class MovieGenresSaveHandler(IRequestContext context) :
    SaveRequestHandlerAsync<MyRow, SaveRequest<MyRow>, SaveResponse>(context),
    IMovieGenresSaveHandler
{
}
