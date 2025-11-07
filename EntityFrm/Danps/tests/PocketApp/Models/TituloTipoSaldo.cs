using System;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Views
{
    public partial class TituloTipoSaldo
    {
        [Key]
        public Guid Id { get; set; }
        
        public long TenantId { get; set; }
        public long ContaCorrenteId { get; set; }
        public string Tipo { get; set; }
        public Decimal Saldo { get; set; }
    }
}