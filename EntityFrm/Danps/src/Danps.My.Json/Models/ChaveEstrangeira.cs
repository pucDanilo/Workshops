using Newtonsoft.Json;

namespace Danps.My.Json.Models
{
    public class Rootobject
    {
        [JsonProperty("dbo")]
        public Banco[] dbo { get; set; }

        [JsonProperty("soluctionName")]
        public string soluctionName { get; set; }
    }

    public class Banco
    {
        [JsonProperty("table")]
        public Tabela table { get; set; }

        [JsonProperty("projeto")]
        public string projeto { get; set; }

    }

    public class Tabela
    {
        [JsonProperty("area")]
        public string area { get; set; }

        [JsonProperty("tableNameOf")]
        public string classe { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("indexes")]
        public Indice[] indexes { get; set; }

        [JsonProperty("columns")]
        public Coluna[] columns { get; set; }
    }

    public class Indice
    {
        [JsonProperty("KeyNameOf")]
        public string KeyNameOf { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("is_unique")]
        public bool is_unique { get; set; }

        [JsonProperty("is_primary_key")]
        public bool is_primary_key { get; set; }

        [JsonProperty("columns")]
        public Coluna[] columns { get; set; }

        [JsonProperty("filter_definition")]
        public string filter_definition { get; set; }
    }

    public class Coluna
    { 
        [JsonProperty("OwnsOne")]
        public string OwnsOne { get; set; }

        [JsonProperty("ColumnNameOf")]
        public string Nome { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("max_length")]
        public int max_length { get; set; }

        [JsonProperty("indexes")]
        public Indice[] indexes { get; set; }

        [JsonProperty("constraints")]
        public Restricao[] constraints { get; set; }

        [JsonProperty("fks")]
        public ChaveEstrangeira[] fks { get; set; }
        
        [JsonProperty("Tipo")]
        public string Tipo { get; set; }
    }

    public class Restricao
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("definition")]
        public string definition { get; set; }
    }

    public class ChaveEstrangeira
    {
        [JsonProperty("referenced_object_id")]
        public long referenced_object_id { get; set; }

        [JsonProperty("referenced_column_id")]
        public int referenced_column_id { get; set; }

        [JsonProperty("FK_CONSTRAINT")]
        public string name { get; set; }

        [JsonProperty("referenced_column")]
        public string referenced_column { get; set; }

        [JsonProperty("referenced_object")]
        public string referenced_object { get; set; }

        [JsonProperty("parent_object")]
        public string parent_object { get; set; }

        [JsonProperty("parent_column")]
        public string parent_column { get; set; }
    }
}