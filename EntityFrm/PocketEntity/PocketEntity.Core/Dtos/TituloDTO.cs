using System;

namespace PocketEntity.Core.Dtos
{
    public class TituloDTO
    {
        public string NomeContaCorrente { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NomeTitulo { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorLiquido { get; set; }
        public long Id { get; set; }
        public string Banco { get; internal set; }
    }
}