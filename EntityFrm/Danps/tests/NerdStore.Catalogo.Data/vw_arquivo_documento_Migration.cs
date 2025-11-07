
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class _v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"/*******************************************************************************************
  SISTEMA.: Gestão de Assinatura Digital							BANCO: smcpbhntsrv1/GAD
  AUTOR...: Danilo Pereira da Silva 		Data: 05/08/2020		SOL..: 977698
  OBJETIVO:	Listar todos os historicos com arquivos associados de um documento 
  ----------------------------------------------------------------------------------------
  EXEMPLO:	
	select * From vw_arquivo_documento where seq_documento = 1 
  ----------------------------------------------------------------------------------------
  MANUTENÇÕES

  DATA:			POR:			SOL.:   
********************************************************************************************/

CREATE VIEW [dbo].[vw_arquivo_documento]
AS
	select	d.seq_documento,
			d.seq_documento as seq_entidade,
			1 idt_dom_tipo_status, 
			h.idt_dom_status_documento as val_status,  
			h.dat_inclusao, 
			a.seq_arquivo,
			a.sgl_aplicacao,
			a.dsc_pasta_aplicacao,
			a.dat_ultimo_download,
			a.qtd_download,
			a.nom_arquivo
	from documento d 
	join historico_status_documento h on h.seq_documento = d.seq_documento and h.seq_arq_anexado is not null
	
	join arquivo a on a.seq_arquivo = h.seq_arq_anexado

union 
	select	d.seq_documento,
			da.seq_documento_assinado as seq_entidade,	
			2 idt_dom_tipo_status, 	
			hda.idt_dom_status_documento_assinado as val_status, 	
			hda.dat_inclusao, 
			a.seq_arquivo,
			a.sgl_aplicacao,
			a.dsc_pasta_aplicacao,
			a.dat_ultimo_download,
			a.qtd_download,
			a.nom_arquivo
	from documento d 
	join documento_assinado da on da.seq_documento = d.seq_documento
	join historico_documento_assinado hda  on hda.seq_documento_assinado = da.seq_documento_assinado and hda.seq_arq_anexado is not null 
	
	join arquivo a on a.seq_arquivo = hda.seq_arq_anexado
union 
	select	d.seq_documento,
			dp.seq_documento_participante as seq_entidade,
			3 idt_dom_tipo_status, 
			hdp.idt_dom_status_documento_participante as val_status,  
			hdp.dat_inclusao, 
			a.seq_arquivo,
			a.sgl_aplicacao,
			a.dsc_pasta_aplicacao,
			a.dat_ultimo_download,
			a.qtd_download,
			a.nom_arquivo
	from documento d 
	join documento_assinado da on da.seq_documento = d.seq_documento
	join documento_participante dp on da.seq_documento_assinado = dp.seq_documento_assinado
	join historico_documento_participante hdp on hdp.seq_documento_participante = dp.seq_documento_participante and hdp.seq_arq_anexado is not null
	 
	join arquivo a on a.seq_arquivo = hdp.seq_arq_anexado

";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP VIEW if exists [dbo].[vw_arquivo_documento]");
        }
    }
