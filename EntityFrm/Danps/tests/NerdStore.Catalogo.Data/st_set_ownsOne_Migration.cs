
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class _v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @" 
CREATE Procedure [dbo].st_set_ownsOne @table_name varchar(200), @column_name varchar(200), @OwnsOne varchar(200) AS
BEGIN 
	
update f 
set f.OwnsOne = @OwnsOne
from my_class m 
join my_class_field f on f.seq_my_class = m.seq_my_class
WHERE m.table_name = @table_name
and f.column_name = @column_name

 
END
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP PROCEDURE if exists [dbo].[st_set_ownsOne]");
        }
    }
