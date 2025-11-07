using System;
using System.Collections.Generic;

namespace SGF.Domain.Models
{
    public partial class Mapeamento
    {
        public virtual long Seq { get; set; }

        public virtual Nullable<long> SeqFonteDados { get; set; }

        public virtual Nullable<long> SeqBlocoColecao { get; set; }

        public virtual string PropriedadeValor { get; set; }

        public virtual string PropriedadeExibicao { get; set; }

        public virtual bool AtualizaAutomaticamente { get; set; }

        public virtual IEnumerable<ParametroMapeamento> Parametros { get; set; }
        public virtual FonteDados FonteDados { get; set; }
        public virtual Elemento BlocoColecao { get; set; }

        public bool Novo
        {
            get { return Seq == default(long); }
        }

        public Mapeamento Clone()
        {
            Mapeamento mapeamento = new Mapeamento();

            mapeamento.AtualizaAutomaticamente = this.AtualizaAutomaticamente;
            mapeamento.SeqFonteDados = this.SeqFonteDados;
            mapeamento.SeqBlocoColecao = this.SeqBlocoColecao;
            mapeamento.PropriedadeValor = this.PropriedadeValor;
            mapeamento.PropriedadeExibicao = this.PropriedadeExibicao;
            var Parametros = new List<ParametroMapeamento>();

            if (this.Parametros != null)
            {
                foreach (var parametro in this.Parametros)
                {
                    Parametros.Add(new ParametroMapeamento()
                    {
                        NomeParametro = parametro.NomeParametro,
                        SeqCampo = parametro.SeqCampo
                    });
                }
            }
            mapeamento.Parametros = Parametros;

            return mapeamento;
        }
    }
}