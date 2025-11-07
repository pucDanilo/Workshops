using Danps.Data;
using PocketEntity.Core.Models;
using System.Linq;

namespace PocketEntity.Core.Data
{
    public static class StockpecificationExtensions
    {
        public static ISpecification<Stock> StockCarteira(this ISpecification<Stock> specification)
        {
            return specification.And(x => x.Pregao.Sum(a => a.Quantidade) > 0);
        }
         
    }
}