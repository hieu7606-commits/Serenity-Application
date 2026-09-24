namespace Serene.MovieDB;

/// <summary>
/// The entity for the Genre table - the list a movie's genre is picked from. Laid out the same way
/// as <see cref="MovieRow"/>; see there for what the attributes mean.
/// </summary>
[ConnectionKey("Default"), Module("MovieDB"), TableName("Genre")]
[DisplayName("Genres"), InstanceName("Genre")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
// LookupScript: publishes the whole table to the client as the "MovieDB.Genre" lookup (key taken
// from module + class name), which is what the Genre dropdown on the movie form reads. Suited to
// small, rarely changing tables; the cached list is refreshed when a genre is saved.
[LookupScript]
public sealed class GenreRow : Row<GenreRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Genre Id"), Identity, IdProperty]
    public int? GenreId { get => fields.GenreId[this]; set => fields.GenreId[this] = value; }

    [DisplayName("Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string? Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field GenreId = null!;
        public StringField Name = null!;
    }
}
