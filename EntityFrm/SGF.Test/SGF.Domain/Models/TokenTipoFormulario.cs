namespace SGF.Domain.Models
{
    public partial class TokenTipoFormulario
    {
        public virtual long Seq { get; set; }
        public virtual long SeqTipoFormulario { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Token { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual bool Colecao { get; set; }
    }
}