using System;
using System.Collections.Generic;
using System.Linq;

namespace SGF.Domain.Models
{
    public class Secao
    {
        public long Seq { get; set; }
        public long SeqFormulario { get; set; }
        public long? SeqSecaoPai { get; set; }
        public string Nome { get; set; }

        public short Ordem { get; set; }

        public string Token { get; set; }

        public Formulario Formulario { get; set; }
        public IEnumerable<Secao> Secoes { get; set; }
        public Secao SecaoPai { get; set; }
        public IEnumerable<Elemento> Elementos { get; set; }

         

        private readonly List<Campo> _campoItens;
        public IReadOnlyCollection<Campo> CamposItens => _campoItens;


        protected Secao()
        {
        }

        public Secao(short ordem, string nome, string token)
        {
            Ordem = ordem;
            this.Nome = nome;
            this.Token = token;
        }
        public string OrdemCompleta
        {
            get
            {
                return (this.SecaoPai != null
                    ? this.SecaoPai.OrdemCompleta
                    : "") + string.Format("{0}.", this.Ordem);
            }
        }

        public string NomeCompleto
        {
            get
            {
                return string.Format("{0} {1}", OrdemCompleta, Nome);
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

        public void AdicionarCampo(int ordem, string nome)
        {
            var campo = new Campo();
            _campoItens.Add(campo); 
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

        public IEnumerable<Rotulo> Rotulos
        {
            get
            {
                if (this.Elementos == null)
                    return Enumerable.Empty<Rotulo>();
                return this.Elementos.OfType<Rotulo>();
            }
        }

        public bool Nova
        {
            get { return Seq == default(long); }
        }

        public Secao Clone()
        {
            Secao secao = new Secao();

            secao.Nome = this.Nome;

            return secao;
        }
    }
}