using FluentMigrator;

namespace Serene.Migrations.DefaultDB;

// Genres are a table rather than an enum like MovieKind because users add to the list over time.
// GenreId on Movie is nullable so existing movies stay valid without one.
[DefaultDB, MigrationKey(20221114_1836)]
public class DefaultDB_20221114_1836_GenreTable : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table("Genre")
            .WithColumn("GenreId").AsInt32().NotNullable().IdentityKey(this)
            .WithColumn("Name").AsString(100).NotNullable();

        Alter.Table("Movie")
            .AddColumn("GenreId").AsInt32().Nullable()
                .ForeignKey("FK_Movie_GenreId", "Genre", "GenreId");

        Insert.IntoTable("Genre")
            .Row(new { Name = "Action" })
            .Row(new { Name = "Drama" })
            .Row(new { Name = "Comedy" })
            .Row(new { Name = "Sci-fi" })
            .Row(new { Name = "Fantasy" })
            .Row(new { Name = "Documentary" });
    }
}
