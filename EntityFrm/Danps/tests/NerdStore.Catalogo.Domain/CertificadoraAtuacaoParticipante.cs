using Danps.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class CertificadoraAtuacaoParticipante : Entity
    {
        public int seq_certificadora { get; private set; }
        public String dsc_token_atuacao { get; private set; }
        public String dsc_atuacao_participante { get; private set; }
        public DateTime dat_inclusao { get; private set; }
        public String usu_inclusao { get; private set; }
        public DateTime dat_alteracao { get; private set; }
        public String usu_alteracao { get; private set; }
        public int seq_certificadora_atuacao_participante { get; private set; }

        protected CertificadoraAtuacaoParticipante()
        {
        }

        public CertificadoraAtuacaoParticipante(
            int seq_certificadora,
            String dsc_token_atuacao,
            String dsc_atuacao_participante,
            DateTime dat_inclusao,
            String usu_inclusao,
            DateTime dat_alteracao,
            String usu_alteracao)
        {
            this.seq_certificadora = seq_certificadora;
            this.dsc_token_atuacao = dsc_token_atuacao;
            this.dsc_atuacao_participante = dsc_atuacao_participante;
            this.dat_inclusao = dat_inclusao;
            this.usu_inclusao = usu_inclusao;
            this.dat_alteracao = dat_alteracao;
            this.usu_alteracao = usu_alteracao;
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O campo Id do produto não pode estar vazio");
        }
    }
}