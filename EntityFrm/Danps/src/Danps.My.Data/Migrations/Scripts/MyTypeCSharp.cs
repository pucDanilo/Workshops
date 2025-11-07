namespace Danps.Core.My.Scripts
{
    public class MyTypeCSharp
	{
		public static string DROP => @"drop functiON if exists MyTypeCSharp";
		public static string SQL => @"CREATE FUNCTION dbo.MyTypeCSharp ( @InputString varchar(4000) )  RETURNS VARCHAR(4000)
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
	}
}
