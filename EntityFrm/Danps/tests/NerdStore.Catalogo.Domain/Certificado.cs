using Danps.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Certificado : Entity, IAggregateRoot
    {
        public int seq_certificadora { get; private set; }
        public int seq_participante { get; private set; }
        public DateTime dat_inicio { get; private set; }
        public DateTime dat_fim { get; private set; }
        public DateTime dat_inclusao { get; private set; }
        public String usu_inclusao { get; private set; }
        public DateTime dat_alteracao { get; private set; }
        public String usu_alteracao { get; private set; }
        public String cod_emissao_1 { get; private set; }
        public String cod_emissao_2 { get; private set; }
        public String num_pedido { get; private set; }
        public String dsc_email { get; private set; }
        public int seq_unidade { get; private set; }
        public String cod_ccusto_ems { get; private set; }
        public String cod_lote { get; private set; }
        public int seq_certificado { get; private set; }

        protected Certificado()
        {
        }

        public Certificado(
            int seq_certificadora,
            int seq_participante,
            DateTime dat_inicio,
            DateTime dat_fim,
            DateTime dat_inclusao,
            String usu_inclusao,
            DateTime dat_alteracao,
            String usu_alteracao,
            String cod_emissao_1,
            String cod_emissao_2,
            String num_pedido,
            String dsc_email,
            int seq_unidade,
            String cod_ccusto_ems,
            String cod_lote)
        {
            this.seq_certificadora = seq_certificadora;
            this.seq_participante = seq_participante;
            this.dat_inicio = dat_inicio;
            this.dat_fim = dat_fim;
            this.dat_inclusao = dat_inclusao;
            this.usu_inclusao = usu_inclusao;
            this.dat_alteracao = dat_alteracao;
            this.usu_alteracao = usu_alteracao;
            this.cod_emissao_1 = cod_emissao_1;
            this.cod_emissao_2 = cod_emissao_2;
            this.num_pedido = num_pedido;
            this.dsc_email = dsc_email;
            this.seq_unidade = seq_unidade;
            this.cod_ccusto_ems = cod_ccusto_ems;
            this.cod_lote = cod_lote;
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O campo Id do produto não pode estar vazio");
        }
    }
}