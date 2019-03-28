using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Models.enCategoria;
using Eventos.IO.Domain.Models.enEndereco;
using Eventos.IO.Domain.Models.enOrganizdor;
using Eventos.IO.Domain.Models.enTag;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models.enEvento
{
    public class Evento : Entity<Evento>
    {
        #region Constructor
        public Evento(string nome, DateTime datainicio, DateTime dataFim, bool gratuito,
            decimal valor, bool online, string nomeDaEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = datainicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;
        }
        #endregion

        #region Properts
        public string Nome { get; private set; }
        public string NomeCurto { get; private set; }
        public string NomeLongo { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeDaEmpresa { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<Tag> Tag { get; set; }
        public Endereco Endereco { get; set; }
        public Organizador Organizador { get; set; }
        #endregion

        #region Validations
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();
        }

        private void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .Length(2, 100).WithMessage("Deve conter no entre 2 e 100 caracteres.");
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(x => x.Valor)
                .ExclusiveBetween(1, 50000).When(x => !x.Gratuito)
                .WithMessage("O valor deve estar entre R$ 1,00 e R$ 50.000,00.");
            else
                RuleFor(x => x.Valor)
                    .ExclusiveBetween(0, 0).When(x => x.Gratuito)
                    .WithMessage("O valor deve ser R$ 0,00 para um Evento Gratuito.");
        }

        private void ValidarData()
        {
            RuleFor(x => x.DataInicio)
                .LessThan(DateTime.Now)
                .WithMessage("A data de início não deve ser menor que a data atual.");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(x => x.Endereco)
                    .Null().When(x => x.Online)
                    .WithMessage("O Evento não deve possuir um endereço se for Online.");
            else
                RuleFor(x => x.Endereco)
                    .Null().When(x => !x.Online)
                    .WithMessage("Para um evento presencial, o endereço é obrigatório.");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(x => x.NomeDaEmpresa)
                .NotEmpty().WithMessage("O Nome da Empresa é obrigatório.")
                .Length(3, 150).WithMessage("O Nome da Empresa deve conter entre 3 e 150 caracteres.");
        }
        #endregion
    }
}
