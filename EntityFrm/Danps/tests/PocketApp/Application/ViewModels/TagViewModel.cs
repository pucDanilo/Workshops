using System;
using System.ComponentModel.DataAnnotations;

namespace PocketApp.Application.ViewModels
{
    public class TagViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }

}
