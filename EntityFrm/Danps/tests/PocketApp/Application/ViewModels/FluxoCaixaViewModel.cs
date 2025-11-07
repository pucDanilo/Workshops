using PocketApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocketApp.Application.ViewModels
{
    public class FluxoCaixaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid LocatarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoCategoria TipoCategoria { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal SaldoAnterior { get; set; }

        public IEnumerable<MovimentacaoViewModel> Movimentacoes { get; set; }
    }
}