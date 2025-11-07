using System;
using System.Collections.Generic;
using System.Linq;

namespace SGF.Domain.Models
{
    public class Bloco : Elemento
    {
        public virtual short? CodigoLayout { get; set; }
        public virtual short? QuantidadeMinima { get; set; }
        public virtual short? QuantidadeMaxima { get; set; }
        public virtual bool Colecao { get; set; }
        public virtual bool IncluiEmJanela { get; set; }
        public virtual IEnumerable<Elemento> Elementos { get; set; }


        public LayoutBloco Layout
        {
            get
            {
                if (this.CodigoLayout.HasValue)
                    return (LayoutBloco)this.CodigoLayout.Value;
                return LayoutBloco.Linear;
            }
            set { this.CodigoLayout = (short)value; }
        }

        public IEnumerable<Campo> Campos
        {
            get
            {
                if (this.Elementos == null)
                    return Enumerable.Empty<Campo>();
                return this.Elementos.OfType<Campo>();
            }
        }

        public IEnumerable<Botao> Botoes
        {
            get
            {
                if (this.Elementos == null)
                    return Enumerable.Empty<Botao>();
                return this.Elementos.OfType<Botao>();
            }
        }

        public IEnumerable<Bloco> Blocos
        {
            get
            {
                if (this.Elementos == null)
                    return Enumerable.Empty<Bloco>();
                return this.Elementos.OfType<Bloco>();
            }
        }

        public IEnumerable<Rotulo> Rotulos
        {
            get
            {
                if (this.Elementos == null)
                    return Enumerable.Empty<Rotulo>();
                return this.Elementos.OfType<Rotulo>();
            }
        }

        public override Elemento Clone()
        {
            Bloco bloco = new Bloco();

            bloco.Nome = this.Nome;
            bloco.Descricao = this.Descricao;
            bloco.CodigoTipoExibicao = this.CodigoTipoExibicao;

            bloco.Colecao = this.Colecao;
            bloco.CodigoLayout = this.CodigoLayout;
            bloco.QuantidadeMinima = this.QuantidadeMinima;
            bloco.QuantidadeMaxima = this.QuantidadeMaxima;
            bloco.IncluiEmJanela = this.IncluiEmJanela;
            bloco.ExibirListagem = this.ExibirListagem;

            return bloco;
        }

        public static bool VerificarHierarquiaIncluiEmJanela(Elemento[] elementos, long seqBloco)
        {
            if (VerificarPaisIncluiEmJanela(elementos, seqBloco))
                return true;

            if (VerificarFilhosIncluiEmJanela(elementos, seqBloco))
                return true;

            return false;
        }

        public static bool VerificarPaisIncluiEmJanela(Elemento[] elementos, long seqBlocoPai)
        {
            var blocoPai = elementos.OfType<Bloco>().SingleOrDefault(b => b.Seq == seqBlocoPai);
            if (blocoPai == null)
                throw new Exception(string.Format("Não foi encontrado bloco com o código '{0}'.", seqBlocoPai));

            if (blocoPai.IncluiEmJanela)
                return true;

            if (blocoPai.SeqBlocoPai.HasValue && VerificarPaisIncluiEmJanela(elementos, blocoPai.SeqBlocoPai.Value))
                return true;

            return false;
        }

        public static bool VerificarFilhosIncluiEmJanela(Elemento[] elementos, long seqBloco)
        {
            foreach (Bloco item in elementos.OfType<Bloco>().Where(b => b.SeqBlocoPai == seqBloco))
            {
                if (item.IncluiEmJanela)
                    return true;

                if (VerificarFilhosIncluiEmJanela(elementos, item.Seq))
                    return true;
            }

            return false;
        }
    }
}