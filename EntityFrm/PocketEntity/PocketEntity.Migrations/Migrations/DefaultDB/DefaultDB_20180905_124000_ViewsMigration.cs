using FluentMigrator;
using System.Text;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180905124000)]
    public class DefaultDB_20180905_124000_ViewsMigrationa : PopularDB
    {
        public override void Up()
        {
            if (true) return;
            StringBuilder vw_chart_ContaCorrente = new StringBuilder();
            vw_chart_ContaCorrente.Append("create view dbo.vw_chart_ContaCorrente as ")
                .Append(" select cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco + ' - ' + cc.NumeroConta as Descricao, sum(t.Valor) as Total")
                .Append(" From	ContaCorrente cc  ")
                .Append(" join	Tenant te on cc.TenantId = te.TenantId")
                .Append(" join	Transacao t on t.ContaCorrenteId = cc.ContaCorrenteId ")
                .Append(" group by cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco, cc.NumeroConta ")
                .Append("    union 	")
                .Append(" select cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco + ' - ' + cc.NumeroConta as Descricao, sum(p.Quantidade*p.Preco)")
                .Append(" From ContaCorrente cc")
                .Append(" join Tenant te on cc.TenantId = te.TenantId ")
                .Append(" join Stock s on s.ContaCorrenteId = cc.ContaCorrenteId")
                .Append(" join Pregao p on p.StockId = s.StockId ")
                .Append(" group by cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco, cc.NumeroConta ")
                .Append(" union ")
                .Append(" select cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco + ' - ' + cc.NumeroConta as Descricao, sum(p.Valor)")
                .Append(" From ContaCorrente cc  ")
                .Append(" join Tenant te on cc.TenantId = te.TenantId")
                .Append(" join Titulo ts on ts.ContaCorrenteId = cc.ContaCorrenteId")
                .Append(" join Protocolo p on ts.TituloId = p.TituloId ")
                .Append(" group by cc.TenantId, cc.ContaCorrenteId, cc.NomeBanco, cc.NumeroConta ");
            IfDatabase("sqlserver").Execute.Sql(vw_chart_ContaCorrente.ToString());

            StringBuilder vw_chart_Stock = new StringBuilder();
            vw_chart_Stock.Append(" create view dbo.vw_chart_Stock as ")
                .Append(" select cc.TenantId, s.StockId, s.Codigo + ' - ' + s.Nome as Descricao, sum(p.Quantidade*p.Preco) as Total")
                .Append(" From	ContaCorrente cc ")
                .Append(" join	Tenant te on cc.TenantId = te.TenantId ")
                .Append(" join	Stock s on s.ContaCorrenteId = cc.ContaCorrenteId")
                .Append(" join	Pregao p on p.StockId = s.StockId ")
                .Append(" group by cc.TenantId, s.StockId, s.Codigo, s.Nome");
            IfDatabase("sqlserver").Execute.Sql(vw_chart_Stock.ToString());

            StringBuilder vw_chart_ContraCheque_Natureza = new StringBuilder();
            vw_chart_ContraCheque_Natureza.Append(" create view dbo.vw_chart_ContraCheque_Natureza as ")
                .Append(" select n.TenantId, t.ContaCorrenteId, n.NaturezaId, n.nome, sum(ch.Valor) Total")
                .Append(" from	ContraCheque ch")
                .Append(" join	Transacao t on t.TransacaoId = ch.TransacaoId")
                .Append(" join	Natureza n on n.NaturezaId = ch.NaturezaId")
                .Append(" group by n.TenantId, t.ContaCorrenteId, n.NaturezaId, n.nome") ;
            IfDatabase("sqlserver").Execute.Sql(vw_chart_ContraCheque_Natureza.ToString());

            StringBuilder vw_chart_ContraCheque = new StringBuilder();
            vw_chart_ContraCheque.Append(" create view dbo.vw_chart_ContraCheque as ")
                .Append(" select n.TenantId, t.ContaCorrenteId, t.Descricao, sum(ch.Valor) as Total ")
                .Append(" from	ContraCheque ch")
                .Append(" join	Transacao t on t.TransacaoId = ch.TransacaoId")
                .Append(" join	Natureza n on n.NaturezaId = ch.NaturezaId")
                .Append(" group by n.TenantId, t.ContaCorrenteId, t.Descricao");
            IfDatabase("sqlserver").Execute.Sql(vw_chart_ContraCheque.ToString());

            StringBuilder vw_chart_natureza = new StringBuilder();
            vw_chart_natureza.Append(" create view dbo.vw_chart_natureza as ")
                .Append(" select n.TenantId, t.ContaCorrenteId, n.nome, sum(t.Valor) as total")
                .Append(" from Transacao t")
                .Append(" join	Natureza n on n.NaturezaId = t.NaturezaId")
                .Append(" group by n.TenantId, t.ContaCorrenteId, n.nome ");
            IfDatabase("sqlserver").Execute.Sql(vw_chart_natureza.ToString());
             

        }

    }
}
