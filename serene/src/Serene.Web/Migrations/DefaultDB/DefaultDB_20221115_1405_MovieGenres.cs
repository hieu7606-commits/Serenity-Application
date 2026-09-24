using FluentMigrator;

namespace Serene.Migrations.DefaultDB;

// Replaces the single Movie.GenreId with a MovieGenres linking table so a movie can have several
// genres. Existing picks are copied across before the column is dropped. ForwardOnly because the
// data move cannot be undone automatically the way a plain schema change can.
[DefaultDB, MigrationKey(20221115_1405)]
public class DefaultDB_20221115_1405_MovieGenres : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table("MovieGenres")
            .WithColumn("MovieGenreId").AsInt32().IdentityKey(this)
            .WithColumn("MovieId").AsInt32().NotNullable()
                .ForeignKey("FK_MovieGenres_MovieId", "Movie", "MovieId")
            .WithColumn("GenreId").AsInt32().NotNullable()
                .ForeignKey("FK_MovieGenres_GenreId", "Genre", "GenreId");

        Execute.Sql(
            @"INSERT INTO MovieGenres (MovieId, GenreId)
                SELECT m.MovieId, m.GenreId
                FROM Movie m
                WHERE m.GenreId IS NOT NULL");

        Delete.ForeignKey("FK_Movie_GenreId")
            .OnTable("Movie");
        Delete.Column("GenreId")
            .FromTable("Movie");
    }
}
