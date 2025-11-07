using FluentMigrator;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180804180000)]
    public class DefaultDB_20180804_180000_TesouroDireto : PopularDB
    {
        public override void Up()
        {
            CriarTitulo(PopularDB.BradescoCorretoraId);
            CriarTitulo(PopularDB.EasynvestId);
        }
    }
}