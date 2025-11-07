using System;
using System.Runtime.Serialization;

namespace PocketEntity.Core.Dtos
{
    [DataContract]
    public class TransacaoDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public decimal Valor { get; set; }

        [DataMember]
        public DateTime Data { get; set; }
    }
}