using System;
using System.Collections.Generic;

namespace SGF.Domain.Models
{
    public partial class FonteGlobal : FonteDados 
    { 
        public virtual Nullable<OrdemItens> OrdemItens { get; set; }        
        public virtual IList<ValorFonte> Valores { get; set; } 

    }
}