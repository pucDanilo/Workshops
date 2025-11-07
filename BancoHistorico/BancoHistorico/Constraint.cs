using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoHistorico.Cadastros.Domain
{
    [Table("Restricoes")]
    public class Constraint
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Name")]
        public string Name { get; private set; }
        [Column("definition")]
        public string definition { get; private set; }
    }
}