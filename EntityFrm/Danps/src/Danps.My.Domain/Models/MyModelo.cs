using Danps.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danps.My.Domain.Models
{
    public class MyModelo : EntityAudit, ICloneable
    {
        public string Nome { get; set; }
        public string Mensagem { get; set; }
        public MyRemetente Remetente { get; set; }
        public string Concatenador { get; set; }

        [InverseProperty("Modelo")]
        public ICollection<MyTag> Tags { get; set; }

        public object Clone()
        {
            return new MyModelo
            {
                Mensagem = this.Mensagem,
                Nome = this.Nome,
                Tags = this.Tags,
            };
        }
    }
}