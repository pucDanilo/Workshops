
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class MyTypeCSharp_Migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"CREATE FUNCTION dbo.MyTypeCSharp ( @InputString varchar(4000) )  RETURNS VARCHAR(4000)
AS
BEGIN

	DECLARE @Index          INT
	DECLARE @Char           CHAR(1)
	DECLARE @PrevChar       CHAR(1)
	DECLARE @OutputString   VARCHAR(4000)

	DECLARE @tabela TABLE (sql varchar(200), clr varchar(200))
	INSERT INTO @tabela (sql, clr)
	values ('varbinary','Byte[]') ,
	('binary','Byte[]') ,
	('varchar','String') ,
	('char','Char') ,
	('nvarchar','String') ,
	('nchar','String') ,
	('text','String') ,
	('ntext','String') ,
	('uniqueidentifier','Guid') ,
	('rowversion','Byte[]') ,
	('bit','Boolean') ,
	('tinyint','Byte') ,
	('smallint','short') ,
	('int','int') ,
	('bigint','int') ,
	('smallmoney','decimal') ,
	('money','decimal') ,
	('numeric','decimal') ,
	('decimal','decimal') ,
	('real','Single') ,
	('float','Double') ,
	('smalldatetime','DateTime') ,
	('datetime','DateTime') ,
	('datetime2','DateTime') ,
	('sql_variant','Object')

	SELECT @OutputString = clr FROM @tabela where sql = LOWER(@InputString)

	RETURN ISNULL(@OutputString, @InputString)
END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP FUNCTION if exists [dbo].[MyTypeCSharp]");
        }
    }
