using FluentMigrator;

namespace Serene.Migrations.DefaultDB;

// A new migration rather than an edit to MovieTable: migrations that already ran never run again.
// The default of 1 (Film) fills in the rows that exist before this column does.
[DefaultDB, MigrationKey(20221114_1825)]
public class DefaultDB_20221114_1825_MovieKind : AutoReversingMigration
{
    public override void Up()
    {
        Alter.Table("Movie")
            .AddColumn("Kind").AsInt32().NotNullable().WithDefaultValue(1);
    }
}
