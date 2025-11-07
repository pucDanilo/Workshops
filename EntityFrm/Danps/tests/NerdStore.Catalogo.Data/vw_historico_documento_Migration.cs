
using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Migrations
{ 
    public partial class _v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            var sql = @"  
/*******************************************************************************************
  SISTEMA.: Gestão de Assinatura Digital							BANCO: smcpbhntsrv1/GAD
  AUTOR...: Danilo Pereira da Silva 		Data: 05/08/2020		SOL..: 977698
  OBJETIVO:	Listar todos os historicos de um documento 
  ----------------------------------------------------------------------------------------
  EXEMPLO:	 
	select * From vw_historico_documento where seq_documento = 1

  ----------------------------------------------------------------------------------------
  MANUTENÇÕES

  DATA:			POR:			SOL.:   
********************************************************************************************/

CREATE VIEW [dbo].[vw_historico_documento]
AS


	select	d.seq_documento,
			d.seq_documento as seq_entidade, 
			cast(0 as int) as seq_certificadora,
			cast(1 as int)  idt_dom_tipo_status,
			h.idt_dom_status_documento  as val_status, 	
			dom.dsc_dominio as dsc_status,
			'Documento - ' + h.dsc_observacao as dsc_observacao, 
			h.usu_inclusao, 
			h.dat_inclusao 
	from documento d 
	join historico_status_documento h on h.seq_documento = d.seq_documento  
	join dominio dom on dom.nom_dominio = 'status_documento' and dom.val_dominio = h.idt_dom_status_documento 
	
union 
	select	d.seq_documento,
			da.seq_documento_assinado as seq_entidade, 
			da.seq_certificadora,
			cast(2 as int)  idt_dom_tipo_status,
			hda.idt_dom_status_documento_assinado as val_status, 
			dom.dsc_dominio as dsc_status,
			cer.nom_certificadora as dsc_observacao, 
			hda.usu_inclusao, 
			hda.dat_inclusao 
	from documento d 
	join documento_assinado da on da.seq_documento = d.seq_documento
	join certificadora cer on cer.seq_certificadora = da.seq_certificadora	
	join historico_documento_assinado hda  on hda.seq_documento_assinado = da.seq_documento_assinado  
	join dominio dom on dom.nom_dominio = 'status_documento_assinado' and dom.val_dominio = hda.idt_dom_status_documento_assinado 
union 
	select	d.seq_documento,
			dp.seq_documento_participante as seq_entidade, 
			da.seq_certificadora,
			cast(3 as int)  idt_dom_tipo_status,  
			hdp.idt_dom_status_documento_participante as val_status,  
			dom.dsc_dominio as dsc_status,
			dp.nom_participante + ' - ' + hdp.dsc_observacao as dsc_observacao, 
			hdp.usu_inclusao,  
			hdp.dat_inclusao 
	from documento d 
	join documento_assinado da on da.seq_documento = d.seq_documento
	join certificadora cer on cer.seq_certificadora = da.seq_certificadora	 
	join documento_participante dp on da.seq_documento_assinado = dp.seq_documento_assinado
	join historico_documento_participante hdp on hdp.seq_documento_participante = dp.seq_documento_participante 
	join dominio dom on dom.nom_dominio = 'status_documento_participante' and dom.val_dominio = hdp.idt_dom_status_documento_participante
	
";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.Sql("DROP VIEW if exists [dbo].[vw_historico_documento]");
        }
    }
