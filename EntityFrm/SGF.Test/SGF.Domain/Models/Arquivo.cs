using System;

namespace SGF.Domain.Models
{
    public class Arquivo
    {
        public virtual string Descricao { get; set; }
        public virtual int? QuantidadeDownloads { get; set; }
        public virtual DateTime? DataUltimoDownload { get; set; }
        public virtual string SiglaAplicacao { get; set; }
        public string FormatarDescricaoArquivo { get; }
        public virtual int Tamanho { get; set; }
        public virtual byte[] Conteudo { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Nome { get; set; }
        public virtual Guid Codigo { get; set; }
    }
}