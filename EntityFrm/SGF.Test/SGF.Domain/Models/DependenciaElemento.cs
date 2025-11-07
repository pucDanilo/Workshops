using System;

namespace SGF.Domain.Models
{
    public partial class DependenciaElemento
    { 
        public virtual long Seq { get; set; }
        public virtual long SeqDependencia { get; set; }
        public virtual long SeqElemento { get; set; } 
        public virtual Nullable<short> CodigoTipoComparacao { get; set; }
        public virtual string ValorDependencia { get; set; }
        public virtual string PropriedadeDependencia { get; set; }    
        public virtual Elemento ElementoDependencia { get; set; }   
        public TipoComparacao? TipoComparacao
        {
            get { return (TipoComparacao?)CodigoTipoComparacao; }
            set { CodigoTipoComparacao = (short?)value; }
        }
    }
}