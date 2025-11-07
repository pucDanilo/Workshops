using System.Collections.Generic;

namespace PocketEntity.Core.Dtos
{
    public class ContaDTO

    {
        public ContaDTO()
        {
            Transacoes = new List<TransacaoDTO>();
        }

        public string Banco { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public List<TransacaoDTO> Transacoes { get; set; }
        public long Id { get; set; }
        public string NomeTenant { get; set; }
    }
}