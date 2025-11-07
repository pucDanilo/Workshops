
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class _v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"CREATE Procedure dbo.st_my_default_db AS
BEGIN

	DECLARE @dat_inclusao datetime = getdate(), @usu_inclusao varchar(20) = 'st_my_default_db'
	IF(NOT EXISTS(SELECT 1 FROM my_replace))
	BEGIN
		INSERT INTO MY_REPLACE (dsc_entrada, dsc_saida, dat_inclusao, usu_inclusao)
		VALUES
			('qtd_', 'Quantidade_', @dat_inclusao, @usu_inclusao),
			('ctd_arquivo', 'Conteudo_',@dat_inclusao, @usu_inclusao),
			('ind_atual', 'Atual_', @dat_inclusao, @usu_inclusao),
			('idt_dom_', '', @dat_inclusao, @usu_inclusao),
			('seq_dom_', 'Identificador_', @dat_inclusao, @usu_inclusao),
			('num_', 'Numero_', @dat_inclusao, @usu_inclusao),
			('sgl_', 'Sigla_', @dat_inclusao, @usu_inclusao),
			('nom_', 'nome_', @dat_inclusao, @usu_inclusao),
			('dsc_', '', @dat_inclusao, @usu_inclusao),
			('cod_', 'Codigo_', @dat_inclusao, @usu_inclusao),
			('obs_', 'Observacao_', @dat_inclusao, @usu_inclusao),
			('ind_', 'Exige_', @dat_inclusao, @usu_inclusao),
			('usu_', 'Usuario_', @dat_inclusao, @usu_inclusao),
			('dat_', 'Data_',getdate(), 'teste')
	end

	INSERT INTO my_class (table_name, class_name, pk_column_name, pk_name, dat_inclusao, usu_inclusao)

		SELECT  OBJECT_NAME(ic.OBJECT_ID),
				dbo.MyDefaultName(OBJECT_NAME(ic.OBJECT_ID)),
				COL_NAME(ic.OBJECT_ID,ic.column_id) ,
			   'Id',
				@dat_inclusao,
				@usu_inclusao
		FROM sys.tables t
		JOIN sys.indexes AS i ON i.object_id = t.object_id
		JOIN sys.index_columns AS ic ON  i.OBJECT_ID = ic.OBJECT_ID AND i.index_id = ic.index_id
		WHERE is_ms_shipped = 0
		AND t.type = 'U'
		AND i.is_primary_key = 1

	INSERT INTO my_class_field (seq_my_class, column_id, column_name, object_name, clr_type, column_type, max_length,  is_primary_key, dat_inclusao, usu_inclusao)
		SELECT	m.seq_my_class,
				c.column_id,
				c.name column_name,
				dbo.MyDefaultName(c.name) object_name,
				dbo.MyTypeCSharp(y.name) clr_type,
				y.name as column_type,
				c.max_length,
				ISNULL(i.is_primary_key, 0) as is_primary_key,
				@dat_inclusao,
				@usu_inclusao
		FROM my_class m
		JOIN sys.tables t ON t.name = m.table_name
		JOIN sys.columns c ON t.object_id = c.object_id
		LEFT JOIN sys.index_columns ic ON  c.object_id = ic.OBJECT_ID and c.column_id = ic.column_id
		LEFT JOIN sys.indexes  i ON i.object_id = ic.object_id AND i.index_id = ic.index_id and  i.is_primary_key = 1
		JOIN sys.types y ON y.user_type_id = c.user_type_id

	INSERT INTO my_class_foreign_key (seq_my_class, table_name, column_name, reference_name, dat_inclusao, usu_inclusao)

		SELECT	seq_my_class, OBJECT_NAME(f.parent_object_id) TableName,
				COL_NAME(fc.parent_object_id, fc.parent_column_id) ColName,
				t.name,
				@dat_inclusao,
				@usu_inclusao
		FROM  sys.foreign_keys AS f
		JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id
		JOIN sys.tables t ON t.OBJECT_ID = fc.referenced_object_id
		JOIN my_class m ON m.table_name = t.name
END
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP PROCEDURE if exists [dbo].[st_my_default_db]");
        }
    }
