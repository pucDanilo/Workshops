using System.Collections.Generic;

namespace Danps.MinhaAPI.Models
{
    public class MyClassModel
    {
        public int Id { get; set; }
        public string NomeTabela { get; set; }
        public string Nome { get; set; }
        public string NomeColuna { get; set; }
        public string NomeChavePrimaria { get; set; }
        public ICollection<MyClassFieldModel> MyClassFields { get; set; }
        public ICollection<MyClassForeignKeyModel> MyClassForeignKeys { get; set; }
    }

    public class MyClassFieldModel
    {
        public int Id { get; set; }
        public int column_id { get; set; }
        public string column_name { get; set; }
        public string clr_type { get; set; }
        public string column_type { get; set; }
        public int? max_length { get; set; }
        public bool is_primary_key { get; set; }
        public string OwnsOne { get; set; }
        public int MyClassId { get; set; }
        public MyClassModel MyClass { get; set; }
    }

    public class MyClassForeignKeyModel
    {
        public int Id { get; set; }
        public string column_name { get; set; }
        public string table_name { get; set; }
        public string reference_name { get; set; }
        public int MyClassId { get; set; }
        public MyClassModel MyClass { get; set; }
    }
}