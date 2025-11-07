using System;
using System.Collections.Generic;

namespace SGF.Domain.Models
{
    public class TipoFormulario
    {
        public long Seq { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Token { get; set; }
        public long? SeqUnidadeGestora { get; set; }
        public long? SeqAplicacaoSAS { get; set; }
        public long SeqUnidadeResponsavel { get; set; }
        public long SeqGrupoAplicacaoSas { get; private set; }
        public IEnumerable<FonteDadosTipoFormulario> FontesDados { get; set; }
        public IEnumerable<Formulario> Formularios { get; set; }

        private readonly List<Visao> _visaoItens;
        public IReadOnlyCollection<Visao> Visoes => _visaoItens;

        public void AdicionarVisao(string nome, string descricao, string token)
        {
            var item = new Visao(nome, descricao, token);
            _visaoItens.Add(item);
        }

        public IEnumerable<TokenTipoFormulario> TokensTipoFormulario { get; set; }

        protected TipoFormulario()
        {
        }

        public TipoFormulario(string nome, string descricao, string token, long seqUnidadeGestora, long seqAplicacaoSAS, long seqUnidadeResponsavel, long seqGrupoAplicacaoSas)
        {
            Nome = nome;
            Descricao = descricao;
            Token = token;
            SeqUnidadeGestora = seqUnidadeGestora;
            SeqAplicacaoSAS = seqAplicacaoSAS;
            SeqUnidadeResponsavel = seqUnidadeResponsavel;
            SeqGrupoAplicacaoSas = seqGrupoAplicacaoSas;
            _visaoItens = new List<Visao>();
            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Token, "O campo Nome do produto não pode estar vazio");
        }
    }
}