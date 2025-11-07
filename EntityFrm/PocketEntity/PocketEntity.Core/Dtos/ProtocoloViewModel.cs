using Danps.CodeGen.Attributes;

namespace PocketEntity.Core.Dtos
{
    public class ProtocoloViewModel
    {
        [ServiceMapperField("ProtocoloId")] public int ProtocoloId { get; set; }
        [ServiceMapperField("TituloId")] public int TituloId { get; set; }
        [ServiceMapperField("TaxaPactuada")] public string TaxaPactuada { get; set; }
        [ServiceMapperField("PrecoUnitario")] public decimal PrecoUnitario { get; set; }
        [ServiceMapperField("Quantidade")] public decimal Quantidade { get; set; }
        [ServiceMapperField("ValorLiquido")] public decimal ValorLiquido { get; set; }
        [ServiceMapperField("ValorInvestido")] public decimal ValorInvestido { get; set; }
        [ServiceMapperField("Valor")] public decimal Valor { get; set; }
        [ServiceMapperField("Data")] public System.DateTime Data { get; set; }
        [ServiceMapperField("NomeTitulo", para = "Titulo.Nome")] public string NomeTitulo { get; set; }
    }
}