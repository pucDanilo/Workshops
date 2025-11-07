using System.ComponentModel;

namespace PocketEntity.Core.Enums
{
    public enum TipoConta : short
    {
        [Description("/Stock/Index")]
        RendaVariavel = 1,

        [Description("/Transacao/Index")]
        ContaCorrente = 2,

        [Description("/Titulo/Index")]
        RendaFixa = 3,

        [Description("/Salarios/Index")]
        Salario = 4
    }
}

/*
 *
update ContaCorrente
set IdentificadorTipoConta = case
	when  descricao = 'Acoes' then 1
	when  descricao = 'ContaCorrente' then 2
	when  descricao = 'Corretora' then 3
	when  descricao = 'Investimento' then 3
	when  descricao = 'Tesouro Direto' then 3
	when  descricao = 'PUC MINAS' then 4
	else 0 end

*/