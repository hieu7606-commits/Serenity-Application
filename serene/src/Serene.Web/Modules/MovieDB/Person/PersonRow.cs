namespace Serene.MovieDB;

/// <summary>
/// The entity for the Person table - actors and actresses, picked from when editing a movie's
/// cast. Laid out the same way as <see cref="MovieRow"/>; see there for what the attributes mean.
/// </summary>
[ConnectionKey("Default"), Module("MovieDB"), TableName("Person")]
[DisplayName("Person"), InstanceName("Person")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
// LookupScript: publishes the "MovieDB.Person" lookup. The cast dialog's Actor/Actress picker and
// MovieCastEditor both read it to turn a PersonId into a name.
[LookupScript]
public sealed class PersonRow : Row<PersonRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Person Id"), Identity, IdProperty]
    public int? PersonId { get => fields.PersonId[this]; set => fields.PersonId[this] = value; }

    [DisplayName("First Name"), Size(50), NotNull]
    public string? FirstName { get => fields.FirstName[this]; set => fields.FirstName[this] = value; }

    [DisplayName("Last Name"), Size(50), NotNull]
    public string? LastName { get => fields.LastName[this]; set => fields.LastName[this] = value; }

    [DisplayName("Birth Date")]
    public DateTime? BirthDate { get => fields.BirthDate[this]; set => fields.BirthDate[this] = value; }

    [DisplayName("Birth Place"), Size(100)]
    public string? BirthPlace { get => fields.BirthPlace[this]; set => fields.BirthPlace[this] = value; }

    [DisplayName("Gender")]
    public Gender? Gender { get => fields.Gender[this]; set => fields.Gender[this] = value; }

    [DisplayName("Height")]
    public int? Height { get => fields.Height[this]; set => fields.Height[this] = value; }

    // Calculated in SQL, not stored. It is the name property - so it titles the dialog and labels
    // the lookup - and quick search, so the grid's search box matches "Keanu Reeves" as a whole.
    // Concat is database-agnostic and treats a NULL part as an empty string.
    [DisplayName("Full Name"), Concat("t0.FirstName", "' '", "t0.LastName"), QuickSearch, NameProperty]
    public string? FullName { get => fields.FullName[this]; set => fields.FullName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field PersonId = null!;
        public StringField FirstName = null!;
        public StringField LastName = null!;
        public DateTimeField BirthDate = null!;
        public StringField BirthPlace = null!;
        public EnumField<Gender> Gender = null!;
        public Int32Field Height = null!;
        public StringField FullName = null!;
    }
}
