using System;
using System.ComponentModel.DataAnnotations;

namespace PocketApp.Application.ViewModels
{
    public class MovimentacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public System.DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid TagId { get; set; }
    }

}
