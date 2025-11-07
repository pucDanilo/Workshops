using Danps.Data;
using PocketEntity.Core.Models;
using System;

namespace PocketEntity.Core.Data
{
    public static class ContaCorrentepecificationExtensions
    {
        public static ISpecification<ContaCorrente> Descricao(this ISpecification<ContaCorrente> specification, string descricao)
        {
            return specification.And(x => x.Descricao.StartsWith(descricao));
        } 

        public static ISpecification<ContaCorrente> CreatedAfter(this ISpecification<ContaCorrente> specification,
            DateTime dateTime)
        {
            return specification.And(x => x.Data >= dateTime);
        }

        /*
                public static ISpecification<ContaCorrente> NotExpired(this ISpecification<ContaCorrente> specification)
                {
                    return specification.NotBanned().NotRemoved();
                }*/
    }
}