using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoHistorico.Cadastros.Domain
{
    public class Fk
    {
        [Key]
        public Guid Id { get; set; }

        [Column("referenced_object_id")]
        public int referenced_object_id { get; private set; }
        [Column("referenced_column_id")]
        public int referenced_column_id { get; private set; }
        [Column("FK_CONSTRAINT")]
        public string FK_CONSTRAINT { get; private set; }
        [Column("referenced_column")]
        public string referenced_column { get; private set; }
        [Column("referenced_object")]
        public string referenced_object { get; private set; }
        [Column("parent_object")]
        public string parent_object { get; private set; }
        [Column("parent_column")]
        public string parent_column { get; private set; }
    }
}