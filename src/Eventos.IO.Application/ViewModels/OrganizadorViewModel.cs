using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class OrganizadorViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11)]
        public string CPF { get; private set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; private set; }
    }
}
