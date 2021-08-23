using System;
using System.ComponentModel.DataAnnotations;

namespace ma9.Business.Models.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 2)]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 9)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }
    }
}
