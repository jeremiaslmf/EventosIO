using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos.IO.Application.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
            Categoria = new CategoriaViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        public string Nome { get; set; }

        [Display(Name = "Descrição curta do Evento")]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descrição longa do Evento")]
        public string DescricaoLonga { get; set; }

        [Display(Name = "Data de Início do Evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Término do Evento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        [Display(Name = "Será Gratuito?")]
        public bool Gratuito { get; set; }

        [Display(Name = "Valor do Evento")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency, ErrorMessage = "Moeda em formato inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Será Online")]
        public bool Online { get; set; }

        [Display(Name = "Empresa / Grupo Organizador")]
        public string NomeDaEmpresa { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public Guid CategoriaId { get; set; }

        public Guid OrganizadorId { get; set; }
    }
}
