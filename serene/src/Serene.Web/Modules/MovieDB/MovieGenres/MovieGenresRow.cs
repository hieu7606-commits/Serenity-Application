namespace Serene.MovieDB;

/// <summary>
/// One movie/genre pair in the MovieGenres linking table. Users never edit these directly: the
/// LinkingSetRelation on <see cref="MovieRow.GenreList"/> inserts and deletes them when a movie is
/// saved, which is why this module has services but no page, grid or dialog.
/// </summary>
[ConnectionKey("Default"), Module("MovieDB"), TableName("MovieGenres")]
[DisplayName("Movie Genres"), InstanceName("Movie Genre")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
public sealed class MovieGenresRow : Row<MovieGenresRow.RowFields>, IIdRow, INameRow
{
    const string jMovie = nameof(jMovie);
    const string jGenre = nameof(jGenre);

    [DisplayName("Movie Genre Id"), Identity, IdProperty]
    public int? MovieGenreId { get => fields.MovieGenreId[this]; set => fields.MovieGenreId[this] = value; }

    [DisplayName("Movie"), NotNull, ForeignKey(typeof(MovieRow)), LeftJoin(jMovie), TextualField(nameof(MovieTitle))]
    public int? MovieId { get => fields.MovieId[this]; set => fields.MovieId[this] = value; }

    [DisplayName("Genre"), NotNull, ForeignKey(typeof(GenreRow)), LeftJoin(jGenre), TextualField(nameof(GenreName))]
    public int? GenreId { get => fields.GenreId[this]; set => fields.GenreId[this] = value; }

    [DisplayName("Movie Title"), Origin(jMovie, nameof(MovieRow.Title))]
    public string? MovieTitle { get => fields.MovieTitle[this]; set => fields.MovieTitle[this] = value; }

    // NameProperty: the linking row has no text column of its own, so the genre name labels it.
    [DisplayName("Genre Name"), Origin(jGenre, nameof(GenreRow.Name)), NameProperty]
    public string? GenreName { get => fields.GenreName[this]; set => fields.GenreName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field MovieGenreId = null!;
        public Int32Field MovieId = null!;
        public Int32Field GenreId = null!;
        public StringField MovieTitle = null!;
        public StringField GenreName = null!;
    }
}
