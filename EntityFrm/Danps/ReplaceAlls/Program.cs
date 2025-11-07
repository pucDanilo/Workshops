using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplaceAlls
{

    /*
            Regex ER = new Regex(@"
        {
            get;
            set;
        }", RegexOptions.IgnoreCase);
            var texto = @"
        [Key]
        [DataMember]
        public virtual int Codigo { get; set; }
        
        [DataMember]
        public virtual int CodigoQuestao
        {
            get;
            set;
        }
        ";
            Console.WriteLine("oi" + ER.IsMatch(texto));*/
    internal class Program
    { 
        public static string[] Campos =
            {

"CodigoAgendamentoRelatorio" ,
"CodigoAgendamentoRelatorioGerencial" ,
"CodigoAreaCurso" ,
"CodigoAreaFormacao" ,
"CodigoComentario" ,
"CodigoConcedente" ,
"CodigoConcedenteArquivo" ,
"CodigoConcedenteComentario" ,
"CodigoConcedenteParecerInterno" ,
"CodigoConcedenteTelefone" ,
"CodigoContaBancaria" ,
"CodigoContrato" ,
"CodigoContratoAluno" ,
"CodigoContratoArquivo" ,
"CodigoContratoAssinatura" ,
"CodigoContratoAssinaturaParticipante" ,
"CodigoContratoAvaliacao" ,
"CodigoContratoComentario" ,
"CodigoContratoCronograma" ,
"CodigoContratoDiarioAtividade" ,
"CodigoContratoFrequenciaAtividade" ,
"CodigoContratoPagamento" ,
"CodigoContratoParecerDocumento" ,
"CodigoContratoParecerInterno" ,
"CodigoContratoRescisao" ,
"CodigoContratoSupervisor" ,
"CodigoConvenio" ,
"CodigoConvenioArquivo" ,
"CodigoConvenioAssinaturaParticipante" ,
"CodigoConvenioAtividade" ,
"CodigoConvenioAtividadeAssinatura" ,
"CodigoConvenioComentario" ,
"CodigoConvenioConcedente" ,
"CodigoConvenioConcedenteEe" ,
"CodigoConvenioContrapartida" ,
"CodigoConvenioCurso" ,
"CodigoConvenioParecerInterno" ,
"CodigoConvenioRepasse" ,
"CodigoConvenioRescisao" ,
"CodigoConvenioResponsavel" ,
"CodigoConvenioSupervisor" ,
"CodigoCoordenadorEstagioOfertaCurso" ,
"CodigoCursoInep" ,
"CodigoCursoOfertaLatoSensu" ,
"CodigoDisciplinaOfertaCurso" ,
"CodigoDisciplinaResponsavelPlano" ,
"CodigoDocumento" ,
"CodigoDocumentoNecessario" ,
"CodigoDominio" ,
"CodigoEntregaRelatorioContrato" ,
"CodigoExcecaoChOfertaCurso" ,
"CodigoFolhaReferencia" ,
"CodigoFolhaReferenciaComentario" ,
"CodigoHistoricoStatusComentario" ,
"CodigoHistoricoStatusConcedente" ,
"CodigoHistoricoStatusContaBancaria" ,
"CodigoHistoricoStatusContrato" ,
"CodigoHistoricoStatusConvenio" ,
"CodigoHistoricoStatusEntregaRelatorio" ,
"CodigoHistoricoStatusFolhaReferencia" ,
"CodigoHistoricoStatusMovimentoPagamento" ,
"CodigoHistoricoStatusOportunidade" ,
"CodigoHistoricoStatusPlanoTrabalho" ,
"CodigoHistoricoStatusProtocoloDocumento" ,
"CodigoHistoricoStatusProtocoloInterno" ,
"CodigoHistoricoStatusSolicitacaoSeguro" ,
"CodigoIntegracaoSispro" ,
"CodigoIntegracaoSisproComentario" ,
"CodigoItemAgendamentoRelatorio" ,
"CodigoJustificativaEstagioObrigatorio" ,
"CodigoManualEntidade" ,
"CodigoModeloDocumento" ,
"CodigoModeloDocumentoArquivo" ,
"CodigoModeloNotificacao" ,
"CodigoMovimentoPagamento" ,
"CodigoNoticia" ,
"CodigoNoticiaArquivo" ,
"CodigoNoticiaPostagem" ,
"CodigoOportunidade" ,
"CodigoOportunidadeArquivo" ,
"CodigoOportunidadeCandidato" ,
"CodigoOportunidadeComentario" ,
"CodigoOportunidadeContato" ,
"CodigoOportunidadeCurso" ,
"CodigoOportunidadeParecerInterno" ,
"CodigoOportunidadeResponsavel" ,
"CodigoPagamentoEstagiario" ,
"CodigoParametro" ,
"CodigoParametroUnidade" ,
"CodigoPlanoTrabalho" ,
"CodigoPlanoTrabalhoAluno" ,
"CodigoPlanoTrabalhoArquivo" ,
"CodigoPlanoTrabalhoComentario" ,
"CodigoPlanoTrabalhoContrato" ,
"CodigoPlanoTrabalhoCronograma" ,
"CodigoPlanoTrabalhoFrequenciaAtividade" ,
"CodigoPlanoTrabalhoParecerInterno" ,
"CodigoPlanoTrabalhoProfessor" ,
"CodigoProjeto" ,
"CodigoProjetoArquivo" ,
"CodigoProjetoComentario" ,
"CodigoProjetoConcedente" ,
"CodigoProjetoContrato" ,
"CodigoProjetoConvenio" ,
"CodigoProjetoCronograma" ,
"CodigoProjetoCurso" ,
"CodigoProjetoDiarioAtividade" ,
"CodigoProjetoParticipante" ,
"CodigoProjetoVagaInterna" ,
"CodigoProtocolo" ,
"CodigoProtocoloDocumento" ,
"CodigoProtocoloInterno" ,
"CodigoProtocoloInternoDocumento" ,
"CodigoReferenciaCalculo" ,
"CodigoReferenciaVigencia" ,
"CodigoRegiao" ,
"CodigoRegiaoUnidade" ,
"CodigoRelatorio" ,
"CodigoRelatorioArquivo" ,
"CodigoRelatorioContrato" ,
"CodigoRelatorioGerencial" ,
"CodigoSecaoEntidade" ,
"CodigoSolicitacaoSeguro" ,
"CodigoStatus" ,
"CodigoTag" ,
"CodigoTagModeloNotificacao" ,
"CodigoTipoAtividade" ,
"CodigoTipoConvenio" ,
"CodigoTipoConvenioAtividade" ,
"CodigoTipoOfertaVaga" ,
"CodigoTurmaComentario" ,
"CodigoTurmaDesbloqueio" ,
"CodigoTurmaDiarioAtividade" ,
"CodigoUnidadeSal" ,
"CodigoUnidadeUsuario" ,
"CodigoUsuario" ,
"CodigoUsuarioComentario" ,
"CodigoUsuarioSolicitacaoSeguro" ,
"CodigoUsuarioTelefone" ,
"CodigoVagaInterna" ,
"CodigoVagaInternaCalendario" };

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var pasta = @"D:\SMC\Dev\Estagios";
                ProcessarDiretorio(pasta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ProcessarDiretorio(string pasta)
        {
            foreach (var diretorio in Directory.GetDirectories(pasta))
            {
                Console.WriteLine(diretorio);
                foreach (var arquivo in Directory.GetFiles(diretorio))
                {
                    var index = arquivo.Substring(arquivo.Length - 3, 3);
                    if (index == ".cs")
                    {
                        //Console.WriteLine($"{diretorio}\\{arquivo}");
                        string text = File.ReadAllText(arquivo);

                        text = Tudo(text);


                        File.WriteAllText(arquivo, text);
                    }
                }
                ProcessarDiretorio(diretorio);
            }
        }

        private static string Tudo(string text)
        {

            text = ReplaceGetSet(text);
            foreach (var campo in Campos)
            {
                text = ReplaceCampoCodigo(text, campo);
            }
            return text;
        }
        private static string ReplaceCampoCodigo(string text, string campo)
        {
            Dictionary<string, string> replaceWith = Replaces(campo);
            foreach (KeyValuePair<string, string> kvp in replaceWith)
            {
                text = text.Replace(kvp.Key, kvp.Value); 
            }

            return text;
        }

        private static Dictionary<string, string> Replaces(string item)
        {
            var camponull = @"
        public virtual Nullable<int> " + item + @"
        ";
            var campolongnull = @"
        public virtual Nullable<long> " + item + @"
        ";
            Dictionary<string, string> replaceWith = new Dictionary<string, string>();
             
            replaceWith.Add(@"        [Key]
        [DataMember]
        public virtual int Codigo { get; set; }", @"        [Key]
        [DataMember]
        public virtual long Codigo { get; set; }");
            replaceWith.Add("public virtual int " + item + " { get; set; }", "public virtual long " + item + " { get; set; }");
            replaceWith.Add("public virtual Nullable<int> " + item + " { get; set; }", "public virtual Nullable<long> " + item + " { get; set; }");
            var campoprivado = item.Replace("Codigo", "_codigo");
            replaceWith.Add($"private int {campoprivado};", $"private long {campoprivado};");
            replaceWith.Add(camponull, campolongnull);
            replaceWith.Add("private Nullable<int> " + campoprivado + ";", "private Nullable<long> " + campoprivado + ";");
            replaceWith.Add($"public virtual int {item}", $"public virtual long {item}");
            foreach (var campo in new string[] { item, item[0].ToString().ToLower() + item.Substring(1) })
            {
                replaceWith.Add($"int? {campo} {{ get; set; }}", $"long? {campo} {{ get; set; }}");
                replaceWith.Add($"int {campo} {{ get; set; }}", $"long {campo} {{ get; set; }}");
                replaceWith.Add($"int? {campo},", $"long? {campo},");
                replaceWith.Add($"int {campo},", $"long {campo},");
                replaceWith.Add($"int? {campo})", $"long? {campo})");
                replaceWith.Add($"int {campo})", $"long {campo})");
                replaceWith.Add($"public int {campo} {{ get; set; }}", $"public long {campo} {{ get; set; }}");
                replaceWith.Add($"public int? {campo} {{ get; set; }}", $"public long? {campo} {{ get; set; }}");
            }

            return replaceWith;
        }

        private static string ReplaceGetSet(string text)
        {
            string oldvalue = @"
        {
            get;
            set;
        }";
            string newValue = " { get; set; }";
            text = text.Replace(oldvalue, newValue);
            return text;
        }
    }
}