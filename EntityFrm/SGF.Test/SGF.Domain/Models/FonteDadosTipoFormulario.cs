namespace SGF.Domain.Models
{
    public partial class FonteDadosTipoFormulario
    {
        public virtual long Seq { get; set; }
        public virtual long SeqFonteDados { get; set; }
        public virtual long SeqTipoFormulario { get; set; }
        public virtual FonteDados FonteDados { get; set; }
        public virtual TipoFormulario TipoFormulario { get; set; }
    }
}