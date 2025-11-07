using Danps.Core.Models;
using System.Linq;
 
namespace PocketEntity.Core.Fakes
{
    public class FakeApiPocket
    {
        public static ApiModelo GetModelo(long id)
        {
            return GetAll().Where(a => a.id == id).Select(b => new ApiModelo() { Controller = b.Controller, id = b.id }).FirstOrDefault();
        }
        public static ApiFormulario[] GetFormulario(long id)
        {
            return GetAll().Where(a => a.id == id).FirstOrDefault().Formulario.ToArray();
        }
        public static ApiModelo[] GetAll( )
        {
            var cont = 1;
            var lista = new ApiModelo[]
            {

                new ApiModelo(){
                    Controller = "/api/v1/ContaCorrente",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "NomeBanco", required = "true", value =  ""},
                        new ApiFormulario { label = "Descricao", required = "true", value =  ""},
                        new ApiFormulario { label = "NumeroConta", required = "true", value =  ""},
                        new ApiFormulario { label = "Data", required = "true", value =  ""},
                        new ApiFormulario { label = "Valor", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                        new ApiFormulario { label = "ContaCorrenteId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/ContaCorrenteSummary",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Descricao", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/ContraChequeNaturezaSummary",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Nome", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/ContraCheque",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "TransacaoId", required = "true", value =  ""},
                        new ApiFormulario { label = "NaturezaId", required = "true", value =  ""},
                        new ApiFormulario { label = "Valor", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                        new ApiFormulario { label = "ContraChequeId", required = "true", value =  ""},
                        new ApiFormulario { label = "ValorTransacao", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/ContraChequeSummary",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Descricao", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Natureza",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Nome", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                        new ApiFormulario { label = "NaturezaId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/NaturezaSummary",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Nome", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Pregao",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "StockId", required = "true", value =  ""},
                        new ApiFormulario { label = "Quantidade", required = "true", value =  ""},
                        new ApiFormulario { label = "Preco", required = "true", value =  ""},
                        new ApiFormulario { label = "Valor", required = "true", value =  ""},
                        new ApiFormulario { label = "Data", required = "true", value =  ""},
                        new ApiFormulario { label = "PregaoId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Protocolo",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "TituloId", required = "true", value =  ""},
                        new ApiFormulario { label = "TaxaPactuada", required = "true", value =  ""},
                        new ApiFormulario { label = "PrecoUnitario", required = "true", value =  ""},
                        new ApiFormulario { label = "Quantidade", required = "true", value =  ""},
                        new ApiFormulario { label = "ValorLiquido", required = "true", value =  ""},
                        new ApiFormulario { label = "ValorInvestido", required = "true", value =  ""},
                        new ApiFormulario { label = "Valor", required = "true", value =  ""},
                        new ApiFormulario { label = "Data", required = "true", value =  ""},
                        new ApiFormulario { label = "ProtocoloId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Stock",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "ContaCorrenteId", required = "true", value =  ""},
                        new ApiFormulario { label = "Codigo", required = "true", value =  ""},
                        new ApiFormulario { label = "Nome", required = "true", value =  ""},
                        new ApiFormulario { label = "DataCotacao", required = "true", value =  ""},
                        new ApiFormulario { label = "Cotacao", required = "true", value =  ""},
                        new ApiFormulario { label = "Quantidade", required = "true", value =  ""},
                        new ApiFormulario { label = "PrecoMedio", required = "true", value =  ""},
                        new ApiFormulario { label = "GanhoTotal", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "StockId", required = "true", value =  ""},
                        new ApiFormulario { label = "NomeContaCorrente", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/StockSummary",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "Descricao", required = "true", value =  ""},
                        new ApiFormulario { label = "Total", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Tenant",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "TenantName", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Titulo",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "ContaCorrenteId", required = "true", value =  ""},
                        new ApiFormulario { label = "Nome", required = "true", value =  ""},
                        new ApiFormulario { label = "Tipo", required = "true", value =  ""},
                        new ApiFormulario { label = "DataVencimento", required = "true", value =  ""},
                        new ApiFormulario { label = "TaxaAtual", required = "true", value =  ""},
                        new ApiFormulario { label = "ValorLiquido", required = "true", value =  ""},
                        new ApiFormulario { label = "ValorInvestido", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                        new ApiFormulario { label = "TituloId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
                new ApiModelo(){
                    Controller = "/api/v1/Transacao",  id = cont++,
                    Formulario = new ApiFormulario[]
                    {
                        new ApiFormulario { label = "ContaCorrenteId", required = "true", value =  ""},
                        new ApiFormulario { label = "NaturezaId", required = "true", value =  ""},
                        new ApiFormulario { label = "Descricao", required = "true", value =  ""},
                        new ApiFormulario { label = "Data", required = "true", value =  ""},
                        new ApiFormulario { label = "Valor", required = "true", value =  ""},
                        new ApiFormulario { label = "TenantId", required = "true", value =  ""},
                        new ApiFormulario { label = "TransacaoId", required = "true", value =  ""},
                        new ApiFormulario { label = "", required = "true", value =  ""},
                    }
                },
            };
            return lista;
        }
    }
}