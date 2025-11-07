using System;
using System.Collections.Generic;
using System.Linq;

namespace SGF.Domain.Models
{
    public class Formulario
    {
        public long Seq { get; set; }
        public Nullable<long> SeqFormularioPai { get; set; }

        public long SeqTipoFormulario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumeroVersao { get; set; }
        public Nullable<System.DateTime> DataPublicacao { get; set; }
        public bool Ativo { get; set; }
        public SituacaoFormulario SituacaoFormulario { get; set; }
         

        private readonly List<Secao> _secaoItens;
        public IReadOnlyCollection<Secao> SecaoItens => _secaoItens;

        public void AtualizarTipoFormulario(TipoFormulario tipoFormulario)
        {
            SeqTipoFormulario = tipoFormulario.Seq;
            TipoFormulario = tipoFormulario;
        }

        public void AdicionarElemento(string tokenSecao, string token, string nome, string descricao)
        {
            throw new NotImplementedException();
        }
        public void AdicionarCampo(string tokenSecao, string token, string nome, string descricao, Campo campo)
        {
            throw new NotImplementedException();
        }
         


        private readonly List<FonteDados> _fonteDadosItens;
        public IReadOnlyCollection<FonteDados> FonteDadosItens => _fonteDadosItens;
        public TipoFormulario TipoFormulario { get; set; }

        protected Formulario()
        {
        }

        public Formulario(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
            SituacaoFormulario = SituacaoFormulario.Em_Manutencao;
            NumeroVersao = 0;
            this._fonteDadosItens = new List<FonteDados>();
            Validar();
        }

        public void Publicar()
        {
            DataPublicacao = DateTime.Now;
            NumeroVersao++;
        }

        private void Validar()
        {
        }
         
        public void AdicionarSecao(short ordem, string nome, string token)
        {
            var item = new Secao(ordem, nome, token);
            _secaoItens.Add(item);
        }

        public void VincularFonte(FonteInterna fonte)
        {
            throw new NotImplementedException();
        }

        ///  sgf

        public bool Novo
        {
            get { return Seq == default(long); }
        }

        public bool Publicado
        {
            get { return this.DataPublicacao.HasValue; }
        }

        public Secao BuscarSecao(long seqSecao)
        {
            if (this.SecaoItens == null)
                throw new Exception("Não existem seções no formulário ou não foram carregadas pelo serviço");
            var secao = this.SecaoItens.FirstOrDefault(s => s.Seq == seqSecao);
            if (secao == null)
                throw new Exception(string.Format("Seção com o código {0} não foi encontrada no formulário", seqSecao));
            return secao;
        }

        public Bloco BuscarBloco(long seqBloco)
        {
            if (this.SecaoItens == null)
                throw new Exception("Não existem seções no formulário ou não foram carregadas pelo serviço");
            var bloco = this.SecaoItens
                .SelectMany(s => s.Blocos)
                .FirstOrDefault(b => b.Seq == seqBloco);
            if (bloco == null)
                throw new Exception(string.Format("Bloco com o código {0} não foi encontrado no formulário", seqBloco));
            return bloco;
        }

        public Elemento BuscarElemento(long seqElemento)
        {
            if (this.SecaoItens == null)
                throw new Exception("Não existem seções no formulário ou não foram carregadas pelo serviço");
            var elemento = this.SecaoItens
                .Where(s => s.Elementos != null)
                .SelectMany(s => s.Elementos)
                .FirstOrDefault(b => b.Seq == seqElemento);
            if (elemento == null)
                throw new Exception(string.Format("Elemento com o código {0} não foi encontrado no formulário", seqElemento));
            return elemento;
        }

        public Elemento BuscarElemento(string token)
        {
            if (this.SecaoItens == null)
                throw new Exception("Não existem seções no formulário ou não foram carregadas pelo serviço");
            var elemento = this.SecaoItens
                .Where(s => s.Elementos != null)
                .SelectMany(s => s.Elementos)
                .FirstOrDefault(b => b.Token == token);
            if (elemento == null)
                throw new Exception(string.Format("Elemento com o token {0} não foi encontrado no formulário", token));
            return elemento;
        }

        public Bloco BuscarBlocoPaiColecao(Elemento elemento)
        {
            if (!elemento.SeqBlocoPai.HasValue)
                return null;

            var pai = this.BuscarBloco(elemento.SeqBlocoPai.Value);
            if (pai.Colecao)
                return pai;

            return BuscarBlocoPaiColecao(pai);
        }

        public Bloco BuscarBlocoPai(Elemento elemento)
        {
            if (!elemento.SeqBlocoPai.HasValue)
                return null;

            var pai = this.BuscarBloco(elemento.SeqBlocoPai.Value);

            return pai;
        }

        public Bloco BuscarBlocoPaiJanela(Elemento elemento)
        {
            if (!elemento.SeqBlocoPai.HasValue)
                return null;

            var pai = this.BuscarBloco(elemento.SeqBlocoPai.Value);
            if (pai.IncluiEmJanela)
                return pai;

            return BuscarBlocoPaiJanela(pai);
        }

        public Formulario Clone()
        {
            Formulario formulario = new Formulario();

            formulario.Nome = this.Nome;
            formulario.Descricao = this.Descricao;
            formulario.SeqTipoFormulario = this.SeqTipoFormulario;

            return formulario;
        }
    }
}