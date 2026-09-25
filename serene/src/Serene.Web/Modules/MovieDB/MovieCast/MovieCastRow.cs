namespace Serene.MovieDB;

/// <summary>
/// One role in one movie: who played it and the character's name. Edited only inside the movie
/// dialog, through <see cref="MovieRow.CastList"/>, and saved with the movie in one transaction -
/// which is why this module has no page of its own.
/// </summary>
[ConnectionKey("Default"), Module("MovieDB"), TableName("MovieCast")]
[DisplayName("Movie Cast"), InstanceName("Movie Cast")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
public sealed class MovieCastRow : Row<MovieCastRow.RowFields>, IIdRow, INameRow
{
    const string jMovie = nameof(jMovie);
    const string jPerson = nameof(jPerson);

    [DisplayName("Movie Cast Id"), Identity, IdProperty]
    public int? MovieCastId { get => fields.MovieCastId[this]; set => fields.MovieCastId[this] = value; }

    // Set by MasterDetailRelation from the movie being saved, never typed by the user - which is
    // why MovieCastForm leaves it out.
    [DisplayName("Movie"), NotNull, ForeignKey(typeof(MovieRow)), LeftJoin(jMovie), TextualField(nameof(MovieTitle))]
    public int? MovieId { get => fields.MovieId[this]; set => fields.MovieId[this] = value; }

    // AsyncLookupEditor: a searchable dropdown fed by the Person lookup, loaded without blocking
    // the page.
    [DisplayName("Actor/Actress"), NotNull, ForeignKey(typeof(PersonRow)), LeftJoin(jPerson), TextualField(nameof(PersonFullName))]
    [AsyncLookupEditor(typeof(PersonRow))]
    public int? PersonId { get => fields.PersonId[this]; set => fields.PersonId[this] = value; }

    [DisplayName("Character"), Size(50), QuickSearch, NameProperty]
    public string? Character { get => fields.Character[this]; set => fields.Character[this] = value; }

    [DisplayName("Movie Title"), Origin(jMovie, nameof(MovieRow.Title))]
    public string? MovieTitle { get => fields.MovieTitle[this]; set => fields.MovieTitle[this] = value; }

    [DisplayName("Actor/Actress"), Origin(jPerson, nameof(PersonRow.FullName))]
    public string? PersonFullName { get => fields.PersonFullName[this]; set => fields.PersonFullName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field MovieCastId = null!;
        public Int32Field MovieId = null!;
        public Int32Field PersonId = null!;
        public StringField Character = null!;
        public StringField MovieTitle = null!;
        public StringField PersonFullName = null!;
    }
}
