using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SGF.Domain.Models
{
    [KnownType(typeof(Campo)), KnownType(typeof(Bloco)), KnownType(typeof(Botao)), KnownType(typeof(Rotulo))]
    public abstract class Elemento
    {
        public virtual long Seq { get; set; }

        public virtual Nullable<long> SeqSecao { get; set; }

        public virtual Nullable<long> SeqBlocoPai { get; set; }

        public virtual Nullable<long> SeqMapeamentoFonte { get; set; }

        public virtual Nullable<System.Guid> SeqImagemExibicao { get; set; }

        public virtual short CodigoTipoExibicao { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string Token { get; set; }

        public virtual short Ordem { get; set; }

        public virtual bool Template { get; set; }

        public virtual bool ExibirListagem { get; set; }
        public virtual Bloco BlocoPai { get; set; }
        public virtual Mapeamento MapeamentoFonte { get; set; }
        public virtual Secao Secao { get; set; }
        public virtual IEnumerable<Dependencia> Dependencias { get; set; }

        public bool Novo
        {
            get { return this.Seq == default(int); }
        }

        public Dependencia BuscarDependencia(TipoDependencia tipoDependencia, long seqVisao)
        {
            if (this.Dependencias == null)
                return null;
            return this.Dependencias.FirstOrDefault(d => d.TipoDependencia == tipoDependencia && d.SeqVisao == seqVisao);
        }

        public TipoExibicao TipoExibicao
        {
            get { return (TipoExibicao)CodigoTipoExibicao; }
            set { CodigoTipoExibicao = (short)value; }
        }

        public Arquivo ImagemExibicao { get; set; }

        public abstract Elemento Clone();
    }
}