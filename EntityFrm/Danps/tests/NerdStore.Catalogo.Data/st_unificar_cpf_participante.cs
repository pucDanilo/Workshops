
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class st_unificar_cpf_participante_Migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"
/***************************************************************************************************************
	OBJETO: st_unificar_cpf_participante
	
	OBJETIVO: Unificar dois participantes que possuem o mesmo CPF
	Regras:
		- Caso algum dos participantes não tenha nenhum documento ou certificado, elimina este
	
	CRIAÇÃO: Carolina Cota (15/04/2021)
	ALTERAÇÃO:
	
	EXEMPLO:
		begin tran

		exec st_unificar_cpf_participante '02315775671', '2322/CAROLINA COTA'

		rollback tran
***************************************************************************************************************/


CREATE PROCEDURE [dbo].[st_unificar_cpf_participante]
	@NUM_CPF varchar(50),
	@USU_UNIFICACAO varchar(255)
AS	
BEGIN

	-- SE O TOTAL DE PARTICIPANTES COM MESMO CPF FOR MAIOR QUE 2, ERRO
	if ((	select	COUNT(*)
			from	participante
			where	num_cpf = @NUM_CPF) <> 2)
	begin
		raiserror ('Rotina unifica apenas 2 participantes. (st_unificar_cpf_participante)', 16, 1)
		return -1
	end

	-- VARIÁVEL AUXILIAR
	declare @SEQ_PARTICIPANTE_EXCLUIR bigint,
			@SEQ_PARTICIPANTE_PERMANECE bigint

	-- INICIA A TRANSAÇÃO
	begin tran

	-- HABILITA O USUÁRIO PARA UNIFICAÇÃO
	declare @DSC_UNIFICACAO varchar(255) = 'GAD - st_unificar_cpf_participante / CPF: ' + cast(@NUM_CPF as varchar)
	exec dpd..st_habilita_usuario @USU_UNIFICACAO, @DSC_UNIFICACAO, 0

	-- CASO ALGUM DOS PARTICIPANTES NÃO TEM CERTIFICADO E NÃO É PARTICIPANTE DE NENHUM DOCUMENTO, EXCLUI ESTE
	if (exists (select	1
				from	participante p
				where	num_cpf = @NUM_CPF
				and		not exists (select 1 from documento_participante where seq_participante = p.seq_participante)
				and		not exists (select 1 from certificado where seq_participante = p.seq_participante)))
	begin
		-- BUSCA O PARTICIPANTE PARA EXCLUSAO
		select	@SEQ_PARTICIPANTE_EXCLUIR = p.seq_participante
		from	participante p
		where	num_cpf = @NUM_CPF
		and		not exists (select 1 from documento_participante where seq_participante = p.seq_participante)
		and		not exists (select 1 from certificado where seq_participante = p.seq_participante)
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao selecionar participante exclusão (1). (st_unificar_cpf_participante)', 16, 1)
			return -1
		end

		-- EXCLUI O PARTICIPANTE QUE NÃO TEM VINCULOS
		delete	participante
		where	seq_participante = @SEQ_PARTICIPANTE_EXCLUIR
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao excluir participante sem vinculo. (st_unificar_cpf_participante)', 16, 1)
			return -1
		end
	end
	-- CASO ALGUM DOS PARTICIPANTES NÃO TEM CERTIFICADO E POSSUI DOCUMENTO, UNIFICA OS DOCUMENTOS E EXCLUI O PARTICIPANTE SEM CERTIFICADO
	else if (exists (select	1
					from	participante p
					where	num_cpf = @NUM_CPF
					and		exists (select 1 from documento_participante where seq_participante = p.seq_participante)
					and		not exists (select 1 from certificado where seq_participante = p.seq_participante)))
	begin
		-- BUSCA O PARTICIPANTE PARA EXCLUSAO
		select	@SEQ_PARTICIPANTE_EXCLUIR = p.seq_participante
		from	participante p
		where	num_cpf = @NUM_CPF
		and		exists (select 1 from documento_participante where seq_participante = p.seq_participante)
		and		not exists (select 1 from certificado where seq_participante = p.seq_participante)
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao selecionar participante exclusão (2). (st_unificar_cpf_participante)', 16, 1)
			return -1
		end

		-- BUSCA O PARTICIPANTE QUE PERMANECE
		select	@SEQ_PARTICIPANTE_PERMANECE = p.seq_participante
		from	participante p
		where	num_cpf = @NUM_CPF
		and		seq_participante <> @SEQ_PARTICIPANTE_EXCLUIR
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao selecionar participante permanece. (st_unificar_cpf_participante)', 16, 1)
			return -1
		end
	
		-- UNIFICA OS DOCUMENTOS
		update	documento_participante
		set	
			seq_participante = 	@SEQ_PARTICIPANTE_PERMANECE,
			usu_alteracao = @USU_UNIFICACAO,
			dat_alteracao = GETDATE()
		where	seq_participante = @SEQ_PARTICIPANTE_EXCLUIR
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao unificar documentos (1). (st_unificar_cpf_participante)', 16, 1)
			return -1
		end

		-- EXCLUI O PARTICIPANTE QUE NÃO TEM CERTIFICADO
		delete	participante
		where	seq_participante = @SEQ_PARTICIPANTE_EXCLUIR
		if (@@ERROR <> 0)
		begin
			rollback transaction  
			raiserror ('Erro ao excluir participante sem certificado. (st_unificar_cpf_participante)', 16, 1)
			return -1
		end
	end

	-- FINALIZA A TRANSAÇÃO E RETORNA
	commit tran
	return 0

END
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP PROCEDURE if exists [dbo].[st_unificar_cpf_participante]");
        }
    }
