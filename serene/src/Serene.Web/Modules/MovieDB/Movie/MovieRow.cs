namespace Serene.MovieDB;

/// <summary>
/// The entity for the Movie table: one instance is one row, and it is the single place the table's
/// shape is described. Everything else in this folder is derived from it - the form, the grid
/// columns, the request handlers and the service - so a column added here is the starting point for
/// showing it anywhere else.
/// </summary>
/// <remarks>
/// Serenity rows are not plain POCOs. Each property reads and writes through a field object in
/// <see cref="RowFields"/>, which is what lets a row track which of its values were actually
/// assigned. That distinction matters on update: only assigned fields are written, so sending a
/// title alone does not blank out the rest of the record.
/// </remarks>
// ConnectionKey: which connection string in appsettings.json this table lives on.
// Module: groups the generated pages and permissions; also the first part of the service URL.
// TableName: the physical table. It does not have to match the class name.
// DisplayName/InstanceName: what the user sees - a page heading and "Edit Movie" style captions.
// Read/Modify/ServiceLookupPermission: who may list, who may change, and who may use it as a
// lookup in another form. Change these to a permission of your own once the module grows.
[ConnectionKey("Default"), Module("MovieDB"), TableName("Movie")]
[DisplayName("Movie"), InstanceName("Movie")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
[ServiceLookupPermission("Administration:General")]
// IIdRow and INameRow let generic code find the identity and the descriptive column without
// knowing anything about Movie: that is how a dialog titles itself and how a lookup shows a label.
public sealed class MovieRow : Row<MovieRow.RowFields>, IIdRow, INameRow
{
    // Identity: the database assigns it. IdProperty: the column IIdRow points at, so this is what
    // Retrieve and Delete requests are keyed by.
    [DisplayName("Movie Id"), Identity, IdProperty]
    public int? MovieId { get => fields.MovieId[this]; set => fields.MovieId[this] = value; }

    // NotNull and Size come from the migration and are enforced before the insert reaches SQL.
    // QuickSearch: the grid's search box looks here. NameProperty: the column INameRow points at.
    [DisplayName("Title"), Size(200), NotNull, QuickSearch, NameProperty]
    public string? Title { get => fields.Title[this]; set => fields.Title[this] = value; }

    [DisplayName("Description"), Size(1000)]
    public string? Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    // No Size attribute: the migration made this nvarchar(max), so there is no length to declare.
    [DisplayName("Storyline")]
    public string? Storyline { get => fields.Storyline[this]; set => fields.Storyline[this] = value; }

    [DisplayName("Year")]
    public int? Year { get => fields.Year[this]; set => fields.Year[this] = value; }

    [DisplayName("Release Date")]
    public DateTime? ReleaseDate { get => fields.ReleaseDate[this]; set => fields.ReleaseDate[this] = value; }

    [DisplayName("Runtime")]
    public int? Runtime { get => fields.Runtime[this]; set => fields.Runtime[this] = value; }

    /// <summary>
    /// The field objects the properties above read and write through. One instance is shared by
    /// every MovieRow, which is why the properties take <c>this</c> as an indexer: the field holds
    /// the metadata, the row instance holds the value.
    /// </summary>
    /// <remarks>
    /// Left unassigned on purpose - Serenity fills these in when the row type is first used, which
    /// is what <c>null!</c> is silencing. Add a property above and its field belongs here too.
    /// </remarks>
    public class RowFields : RowFieldsBase
    {
        public Int32Field MovieId = null!;
        public StringField Title = null!;
        public StringField Description = null!;
        public StringField Storyline = null!;
        public Int32Field Year = null!;
        public DateTimeField ReleaseDate = null!;
        public Int32Field Runtime = null!;

    }
}