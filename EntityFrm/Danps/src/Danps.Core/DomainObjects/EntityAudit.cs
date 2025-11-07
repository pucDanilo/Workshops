using System;

namespace Danps.Core.DomainObjects
{
    public abstract class EntityAudit : Entity, IAudit
    {
        protected EntityAudit() : base()
        {
            UsuarioInclusao = "DEV";
            DataAlteracao = DateTime.Now;
            DataInclusao = DateTime.Now;
        }

        public System.DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public System.DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
    }
}