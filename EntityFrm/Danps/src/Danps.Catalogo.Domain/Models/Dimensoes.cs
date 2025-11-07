using System.ComponentModel.DataAnnotations.Schema;

namespace Danps.Catalogo.Domain.Models
{

    public class Dimensoes
    {
        [Column("Altura")]
        public decimal Altura { get; private set; }

        [Column("Largura")]
        public decimal Largura { get; private set; }

        [Column("Profundidade")]
        public decimal Profundidade { get; private set; }
    }
}