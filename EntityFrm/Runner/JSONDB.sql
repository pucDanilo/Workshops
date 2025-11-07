 
select '' as [soluctionName], 
(
	select	'' as [projeto], 
			(
			SELECT	
					'' as [area], 
					'' as [tableNameOf],
					t.OBJECT_ID as [id], 
					OBJECT_NAME(t.object_id) as [name],
					(
						SELECT	'' KeyNameOf, 
								i.name AS [name], 
								i.is_unique  AS [is_unique], 
								i.is_primary_key AS [is_primary_key], 
								i.filter_definition AS [filter_definition],
								(
									select	COL_NAME(ic.OBJECT_ID,ic.column_id) AS [name], ic.column_id AS [id]
									from sys.index_columns ic
									where i.OBJECT_ID = ic.OBJECT_ID AND i.index_id = ic.index_id
									FOR JSON PATH
								)as [columns]

						FROM    sys.indexes AS i 
						WHERE   i.object_id = t.object_id
						FOR JSON PATH
					) as [indexes],
		
					(
						select	 
								'' as [OwnsOne], 
								'' ColumnNameOf, 
								c.column_id as [id],
								c.name  as [name], 
								(select top 1 y.name from sys.types y where y.user_type_id = c.user_type_id) as [type],
								c.max_length  as [max_length],   
								(
									select	fk.referenced_object_id, 
											fk.referenced_column_id,
											OBJECT_NAME(fk.constraint_object_id)as FK_CONSTRAINT,
											COL_NAME(fk.referenced_object_id, fk.referenced_column_id) referenced_column, 		
											OBJECT_NAME(fk.referenced_object_id) as referenced_object,		
											OBJECT_NAME(fk.parent_object_id) as parent_object,
											COL_NAME(fk.parent_object_id, fk.parent_column_id) parent_column	 
									from sys.foreign_key_columns as fk 
									where  fk.referenced_object_id = c.object_id  and fk.referenced_column_id = c.column_id
									FOR JSON AUTO 
								) as   [fks],
								(
									SELECT	'' KeyNameOf, 
											i.name AS [name], 
											i.is_unique  AS [is_unique], 
											i.is_primary_key AS [is_primary_key], 
											i.filter_definition AS [filter_definition]
									FROM    sys.indexes AS i 
									join  sys.index_columns ic on i.OBJECT_ID = ic.OBJECT_ID AND i.index_id = ic.index_id
									WHERE   ic.object_id = c.object_id  and ic.column_id  = c.column_id
									FOR JSON PATH
								) as [indexes],

								(
									select dc.Name, dc.definition from sys.default_constraints dc WHERE dc.parent_object_id = c.object_id AND c.column_id = dc.parent_column_id
									FOR JSON PATH

								) as [constraints]
						from sys.columns c 			
						where  c.object_id = t.object_id  
						FOR JSON PATH
				) as [columns]
				FROM  sys.tables t   
				where 	t.type = 'U'  
				FOR JSON PATH 
		) as [table] 
		FOR JSON PATH 
) as [dbo]

FOR JSON PATH 