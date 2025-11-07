using System;

namespace Danps.Core.DomainObjects
{
    public interface IAudit
    {
        DateTime DataInclusao { get; set; }
        string UsuarioInclusao { get; set; }
        DateTime? DataAlteracao { get; set; }
        string UsuarioAlteracao { get; set; }
    }
}