using Danps.Data;
using PocketEntity.Core.Models;
using System;

namespace PocketEntity.Core.Data
{
    public static class ContraChequepecificationExtensions
    { 

        public static ISpecification<ContraCheque> MinimoValorLancamento(this ISpecification<ContraCheque> specification, decimal valor)
        {
            return specification.And(x => x.Valor > valor);
        }

        public static ISpecification<ContraCheque> MaximoValorLancamento(this ISpecification<ContraCheque> specification, decimal valor)
        {
            return specification.And(x => x.Valor < valor);
        }
    }
}