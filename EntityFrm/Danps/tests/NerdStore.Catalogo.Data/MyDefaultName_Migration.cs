
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class _v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"
CREATE FUNCTION dbo.MyDefaultName ( @InputString varchar(4000) )  RETURNS VARCHAR(4000)
AS
BEGIN

	DECLARE @Index          INT
	DECLARE @Char           CHAR(1)
	DECLARE @PrevChar       CHAR(1)
	DECLARE @OutputString   VARCHAR(4000)

	DECLARE @DE VARCHAR(10), @PARA VARCHAR(200)
	SET @Index = 1

	DECLARE cr_replace cursor fast_forward for
		select dsc_entrada, dsc_saida from my_replace

	open cr_replace

	fetch next from cr_replace into @de, @para

	while (@@fetch_status = 0)
	begin

		set @InputString =  REPLACE(@InputString, @de, @para)
		fetch next from cr_replace into @de, @para
	end

	SET @OutputString = LOWER(@InputString)

	WHILE @Index <= LEN(@InputString)
	BEGIN
		SET @Char     = SUBSTRING(@InputString, @Index, 1)
		SET @PrevChar = CASE WHEN @Index = 1 THEN''
							 ELSE SUBSTRING(@InputString, @Index - 1, 1)
						END

		IF @PrevChar IN ('',';',':','!','?',',','.','_','-','/','&','''','(')
			SET @OutputString = STUFF(@OutputString, @Index, 1, UPPER(@Char))

		SET @Index = @Index + 1
	END

	RETURN replace(@OutputString,'_','')

END
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP FUNCTION if exists [dbo].[MyDefaultName]");
        }
    }
