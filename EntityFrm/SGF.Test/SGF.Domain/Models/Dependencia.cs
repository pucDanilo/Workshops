using System;
using System.Collections.Generic;

namespace SGF.Domain.Models
{
    public partial class Dependencia
    {
        public virtual long Seq { get; set; }
        public virtual long SeqElemento { get; set; }
        public virtual Nullable<long> SeqVisao { get; set; }
        public virtual short CodigoTipoDependencia { get; set; }
        public virtual IEnumerable<DependenciaElemento> DependenciasCampos { get; set; }

        public TipoDependencia TipoDependencia
        {
            get { return (TipoDependencia)CodigoTipoDependencia; }
            set { CodigoTipoDependencia = (short)value; }
        }

        public Dependencia Clone()
        {
            Dependencia dependencia = new Dependencia();
            dependencia.CodigoTipoDependencia = this.CodigoTipoDependencia;
            var DependenciasCampos = new List<DependenciaElemento>();

            if (this.DependenciasCampos != null)
            {
                foreach (var dependenciaCampo in this.DependenciasCampos)
                {
                    DependenciasCampos.Add(new DependenciaElemento()
                    {
                        SeqElemento = dependenciaCampo.SeqElemento,
                        CodigoTipoComparacao = dependenciaCampo.CodigoTipoComparacao,
                        ValorDependencia = dependenciaCampo.ValorDependencia,
                        PropriedadeDependencia = dependenciaCampo.PropriedadeDependencia
                    });
                }
            }
            dependencia.DependenciasCampos = DependenciasCampos;

            return dependencia;
        }
    }
}