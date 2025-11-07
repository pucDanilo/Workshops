declare @seq_formulario int = 1



select 'var tipoFormulario' + cast(t.seq_tipo_formulario as varchar) +' = new TipoFormulario(' + 
isnull('"' +cast(t.nom_tipo_formulario as varchar) + '"', 'null') + ',' +  
isnull('"' + cast( t.dsc_tipo_formulario as varchar) + '"' , 'null') + ',' +  
+ isnull('"' + cast( t.dsc_token as varchar) + '"' , 'null') + ',' +  
isnull(cast(cod_unidade_gestora as varchar), 'null') + ',' +  
isnull(cast(seq_aplicacao_sas as varchar), 'null') + ',' +  
isnull(cast(seq_unidade_responsavel as varchar), 'null') + ',' +  
isnull(cast(seq_grupo_aplicacao_sas as varchar), 'null')+ ');' -- , t.* 
From sgf..tipo_formulario t
join sgf..formulario f on t.seq_tipo_formulario = f.seq_tipo_formulario 
where f.seq_formulario = @seq_formulario 

select 'tipoFormulario' + cast(t.seq_tipo_formulario as varchar) +'.AdicionarVisao(' + 
+ isnull('"' + cast( v.nom_visao as varchar) + '"' , 'null') + ',' +  
+ isnull('"' + cast( v.dsc_visao as varchar) + '"' , 'null') + ',' +  
+ isnull('"' + cast( v.dsc_token as varchar) + '"' , 'null') + ');' -- , v.*
From sgf..visao v 
join sgf..tipo_formulario t on v.seq_tipo_formulario = t.seq_tipo_formulario
join sgf..formulario f on t.seq_tipo_formulario = f.seq_tipo_formulario 
where f.seq_formulario = @seq_formulario 


select 'var form = new Formulario("' + nom_formulario + '", "' + dsc_formulario + '");
form.AtualizarTipoFormulario(tipoFormulario' + cast(seq_tipo_formulario as varchar) +');'-- , * 
from sgf..formulario where seq_formulario = @seq_formulario

-- 
 
-- FonteInterna
select	'var fonte_' + cast(f.seq_fonte_dados as varchar) + ' = new FonteInterna('
+ isnull('"' + cast( f.nom_fonte_dados as varchar) + '"' , 'null') + ',' + 
+ isnull('"' + cast( f.dsc_fonte_dados as varchar) + '"' , 'null') + ',' + 
+ isnull('"' + cast( f.dsc_token as varchar) + '"' , 'null') + ', (OrdemItens)' + 
isnull(cast(f.idt_dom_ordem_itens as varchar), 'null') + ');' -- , *
From	sgf..fonte_dados f where seq_formulario = @seq_formulario -- and idt_dom_tipo_fonte = 1 
order by f.seq_fonte_dados

select 'fonte_' + cast(f.seq_fonte_dados as varchar) + '.AdicionarItem('  
+ isnull('"' + cast( i.val_item_fonte_dados as varchar) + '"' , 'null') + ',' + 
+ isnull('"' + cast( i.dsc_item_fonte_dados as varchar) + '"' , 'null') +  ');' 
From	sgf..fonte_dados f 
join sgf..item_fonte_dados i on i.seq_fonte_dados = f.seq_fonte_dados 
where f.seq_formulario = @seq_formulario -- and idt_dom_tipo_fonte = 1 
order by f.seq_fonte_dados




select	'form.VincularFonte(fonte_' + cast(f.seq_fonte_dados as varchar) + ');'
From	sgf..fonte_dados f where seq_formulario = @seq_formulario -- and idt_dom_tipo_fonte = 1 
order by f.seq_fonte_dados 
 

 
select 'var Secao' + cast(seq_secao as varchar) + ' = new Secao(' + cast(ord_secao as varchar) + ', "' + nom_secao + '", "' + dsc_token +'");'-- , * 
From sgf..secao where seq_formulario = @seq_formulario



 
select 'Secao' + cast(e.seq_secao as varchar) + '.AdicionarCampo(' + cast(e.ord_elemento as varchar) + ', "' + e.nom_elemento + '");'-- , * 
From sgf..elemento e
join sgf..secao s  on e.seq_secao = s.seq_secao 
where s.seq_formulario = @seq_formulario and e.idt_dom_tipo_elemento = 2




			 /*
select

'var campo'+ cast(e.seq_elemento as varchar) + ' = new Campo(' + 

cast(e.idt_dom_tipo_campo as varchar)  + ',' +
isnull(cast(e.idt_dom_tipo_formato_data_campo as varchar), 'null') + ',' + 
isnull(cast(e.idt_dom_tipo_formato_objetivo_campo as varchar), 'null') + ',' + 
isnull(cast(e.idt_dom_tipo_arquivo_campo as varchar), 'null') + ',' + 
'"' + isnull(e.dsc_texto_ajuda_campo, 'null') + '", ' +
'"' + isnull(e.dsc_mascara_campo, 'null') +  '", ' + 
'"' + isnull(e.val_padrao_campo, 'null') +  '", ' + 
isnull(cast(e.qtd_maximo_caracteres_campo as varchar), 'null') + ',' + 
isnull(cast(e.qtd_casas_decimais_campo as varchar), 'null') + ',' + 
case when e.ind_multiplas_linhas_campo = 1 then 'true' else 'false' end + ','+ 
'"' + isnull(e.dsc_extensoes_validas_campo, null) + '"); ' + CHAR(13)+CHAR(10) + + CHAR(13)+CHAR(10) + + CHAR(13)+CHAR(10) +
'form.AdicionarCampo("' + s.dsc_token + '", "' + 
e.dsc_token + '", "' +
e.nom_elemento + '", "' +
e.dsc_elemento+ '", campo'+ cast(e.seq_elemento as varchar) +  ');', 
e.idt_dom_tipo_campo, e.idt_dom_tipo_exibicao, e.dsc_texto_ajuda_campo, e.num_tamanho_campo, e.idt_dom_formato_texto,  e.* 
from sgf..elemento e
join sgf..secao s on s.seq_secao = e.seq_secao
join sgf..formulario f on f.seq_formulario = s.seq_formulario
where f.seq_formulario = @seq_formulario  

*/

/*
    public class CampoConfiguracao
    {  
        public string TextoAjuda { get; set; } 
        public TipoCampo TipoCampo { get; set; } 
        public Nullable<FormatoTexto> FormatoTexto { get; set; } 
        public Nullable<FormatoData> FormatoData { get; set; }
        public Nullable<System.DateTime> DataMinima { get; set; }
        public Nullable<System.DateTime> DataMaxima { get; set; }
        public Nullable<ReferenciaData> ReferenciaDataMinima { get; set; } 
        public Nullable<ReferenciaData> ReferenciaDataMaxima { get; set; } 
        public Nullable<FormatoObjetivo> FormatoObjetivo { get; set; } 
        public Nullable<short> QuantidadeMinima { get; set; } 
        public Nullable<short> QuantidadeMaxima { get; set; }

        public TipoArquivo?  TipoArquivo { get; set; } 
        //public long? SeqArquivoAnexado { get; set; } 
        //public SMCUploadFile ArquivoAnexado { get; set; }
        public Nullable<FormatoNumero> FormatoNumero { get; set; } 
        public Nullable<NomeLookup> NomeLookup { get; set; } 
        public string Mascara { get; set; } 
        public Nullable<short> MaximoCaracteres { get; set; } 
        public Nullable<short> QuantidadeCasasDecimais { get; set; } 
        public bool MultiplasLinhas { get; set; } 
        public int TamanhoElemento { get; set; }
        public string Formula { get; set; }
        public bool? Totalizar { get; set; }]
        public string TituloCampoTotal { get; set; }

        public bool UniqueBloco { get; set; }
        public Nullable<decimal> ValorMinimo { get; set; }
        public Nullable<decimal> ValorMaximo { get; set; }
        public Nullable<int> QuantidadeMaximaBytesArquivo { get; set; }
        public bool PermiteEnderecoInternacional { get; set; }
        public bool ExibeCorrespondencia { get; set; }
    }*/	

	/*
EXEC dpd..st_habilita_usuario 'Acerto de dados', 'Correção Formulario odontologia', 1029139 
select *, 'http://web.desenvolvimento.pucminas.br/SGF.Aplicacao/FRM/Aplicacao?uid='+ uid_aplicacao  from sgf..aplicacao_formulario where uid_aplicacao ='C3FE7A51-E4DE-49D3-BAAE-895878F3937D'
update sgf..aplicacao_formulario set seq_formulario = 399, dat_fim_aplicacao = getdate() +10, dat_alteracao = getdate(), usu_alteracao = 'tste' where uid_aplicacao ='C3FE7A51-E4DE-49D3-BAAE-895878F3937D'
--select * From gde..parametro 

*/