namespace SGF.Domain.Models
{
    public partial class Botao : Elemento
    {
        public virtual short CodigoTipoAcao { get; set; }

        internal virtual long? SeqAlvo { get; set; }

        public TipoAcao TipoAcao
        {
            get { return (TipoAcao)CodigoTipoAcao; }
            set { CodigoTipoAcao = (short)value; }
        }

        public long? SeqAlvoSecao
        {
            get
            {
                if (this.TipoAcao == TipoAcao.AbrirSecao)
                    return this.SeqAlvo;
                return null;
            }
            set
            {
                if (this.TipoAcao == TipoAcao.AbrirSecao)
                    this.SeqAlvo = value;
            }
        }

        public long? SeqAlvoBlocoJanela
        {
            get
            {
                if (this.TipoAcao == TipoAcao.AbrirBlocoJanela)
                    return this.SeqAlvo;
                return null;
            }
            set
            {
                if (this.TipoAcao == TipoAcao.AbrirBlocoJanela)
                    this.SeqAlvo = value;
            }
        }

        public long? SeqAlvoElementoFonte
        {
            get
            {
                if (this.TipoAcao == TipoAcao.AtualizarElementoFonteDados)
                    return this.SeqAlvo;
                return null;
            }
            set
            {
                if (this.TipoAcao == TipoAcao.AtualizarElementoFonteDados)
                    this.SeqAlvo = value;
            }
        }

        public long? SeqAlvoBlocoColecao
        {
            get
            {
                if (this.TipoAcao == TipoAcao.AdicionarItemColecao
                    || this.TipoAcao == TipoAcao.EditarItemColecao
                    || this.TipoAcao == TipoAcao.ExcluirItemColecao)
                    return this.SeqAlvo;              
                return null;
            }
            set
            {
                if (this.TipoAcao == TipoAcao.AdicionarItemColecao
                    || this.TipoAcao == TipoAcao.EditarItemColecao
                    || this.TipoAcao == TipoAcao.ExcluirItemColecao)
                    this.SeqAlvo = value;
            }
        }

        public override Elemento Clone()
        {
            Botao botao = new Botao();

            botao.Nome = this.Nome;
            botao.Descricao = this.Descricao;
            botao.CodigoTipoExibicao = this.CodigoTipoExibicao;
            botao.ExibirListagem = this.ExibirListagem;
            botao.SeqAlvo = this.SeqAlvo;
            botao.CodigoTipoAcao = this.CodigoTipoAcao;

            return botao;
        }
    }
}