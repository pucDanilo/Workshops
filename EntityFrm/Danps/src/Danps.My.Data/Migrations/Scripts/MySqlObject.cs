namespace Danps.Core.My.Scripts
{
    public class MySqlObject
	{
		public static string DROP => @"drop view if exists my_sql_object";
		public static string SQL => @"
CREATE VIEW dbo.my_sql_object AS  
SELECT	O.name ObjectName, 
		M.definition, 
		cast(O.type_desc as varchar(200)) ObjectType,
		O.type, 
		('DROP ' + 
		case 
			when o.type = 'V' then 'VIEW' 
			when o.type = 'FN' then 'FUNCTION' 
			when o.type = 'P ' then 'PROCEDURE' 
		end +
		' if exists [' + SCHEMA_NAME(o.schema_id) + '].[' + o.name + ']') AS  ObjectDrop
FROM sys.sql_modules m 
INNER JOIN sys.objects o ON m.object_id = o.object_id 
WHERE o.type_desc in ('VIEW', 'SQL_TABLE_VALUED_FUNCTION', 'SQL_STORED_PROCEDURE', 'SQL_SCALAR_FUNCTION' )
and charindex('my', O.name) = 0  
";
	}
}
