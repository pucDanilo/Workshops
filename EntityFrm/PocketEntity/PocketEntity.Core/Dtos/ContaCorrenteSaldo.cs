using PocketEntity.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketEntity.Core.Dtos

{
    public partial class ContaCorrentealdo
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public string Banco { get; set; }
        public string Descricao { get; set; }
        public string Conta { get; set; }
        public Decimal Total { get; set; }
        public int IdentificadorTipoConta { get; set; }
   
        [NotMapped]
        public TipoConta TipoConta
        {
            get { return (TipoConta)this.IdentificadorTipoConta; }
            set
            {
                this.IdentificadorTipoConta = (int)value;
            }
        }
    }
}