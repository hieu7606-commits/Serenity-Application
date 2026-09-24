namespace Serene.MovieDB;

/// <summary>
/// What sort of production a movie record is. Stored in the Kind column as its integer value, so
/// never renumber an existing member - add new ones with new numbers.
/// </summary>
// EnumKey: the name the client knows this enum by; it also prefixes the translation keys for the
// Description texts shown in the dropdown.
[EnumKey("MovieDB.MovieKind")]
public enum MovieKind
{
    [Description("Film")]
    Film = 1,
    [Description("TV Series")]
    TvSeries = 2,
    [Description("Mini Series")]
    MiniSeries = 3
}
