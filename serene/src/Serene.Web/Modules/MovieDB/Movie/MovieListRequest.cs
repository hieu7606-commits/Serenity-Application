namespace Serene.MovieDB;

/// <summary>
/// The Movie list request, plus a Genres filter. It is a separate parameter rather than an
/// equality filter on GenreList because matching has to look into the MovieGenres linking table,
/// which <see cref="MovieListHandler"/> does itself.
/// </summary>
public class MovieListRequest : ListRequest
{
    /// <summary>Genre ids; a movie matches if it has any of them. Null or empty: no filter.</summary>
    public List<int>? Genres { get; set; }
}
