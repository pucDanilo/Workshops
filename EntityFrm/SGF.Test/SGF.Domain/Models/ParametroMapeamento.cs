namespace SGF.Domain.Models
{
    public partial class ParametroMapeamento
    {
        public virtual long Seq { get; set; }

        public virtual long SeqMapeamento { get; set; }

        public virtual long SeqCampo { get; set; }

        public virtual string NomeParametro { get; set; }

        public virtual string UsuarioAlteracao { get; set; }

        public bool Novo
        {
            get { return Seq == default(long); }
        }
    }
}