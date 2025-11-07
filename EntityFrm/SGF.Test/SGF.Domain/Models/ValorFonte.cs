namespace SGF.Domain.Models
{
    public class ValorFonte
    {
        public ValorFonte(long seq, string valor, string texto)
        {
            this.SeqFonteDados = seq;
            this.Valor = valor;
            this.Texto = texto;
            Ativo = true;
        }

        public long Seq { get; set; }
        public long SeqFonteDados { get; set; }
        public string Valor { get; set; }
        public string Texto { get; set; }
        public bool Ativo { get; set; }
        public FonteInterna FonteInterna { get; set; }
        public FonteGlobal FonteGlobal { get; set; }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}