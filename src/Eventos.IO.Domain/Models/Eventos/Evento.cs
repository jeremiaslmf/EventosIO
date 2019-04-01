using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Models.Organizadores;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models.Eventos
{
    public class Evento : Entity<Evento>
    {
        #region Constructors
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

        private Evento() { }
        #endregion

        #region Properties
        public string Nome { get; private set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Gratuito { get; private set; }
        public decimal Valor { get; private set; }
        public bool Online { get; private set; }
        public string NomeDaEmpresa { get; private set; }
        public bool Excluido { get; private set; }
        public virtual ICollection<Tag> Tags { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid OrganizadorId { get; private set; }

        // Propriedades de Navegação - EF
        public virtual Categoria Categoria { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Organizador Organizador { get; private set; }
        #endregion

        #region Methods
        public void AtribuirEndereco(Endereco endereco)
        {
            if (!endereco.IsValid())
                return;
            Endereco = endereco;
        }

        public void AtribuirCategoria(Categoria categoria)
        {
            if (!categoria.IsValid())
                return;
            Categoria = categoria;
        }

        public void ExcluirEvento()
        {
            // TODO: Validações para exclusão
            Excluido = true;
        }
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
            ValidationResult = Validate(this);

            //Validações Adicionais - se chamar antes ele sobrescreve as validações acima
            ValidarEndereco();
        }

        private void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.")
                .Length(2, 100).WithMessage("Deve conter entre 2 e 100 caracteres.");
        }

        private void ValidarValor()
        {
            if (!Gratuito)
                RuleFor(x => x.Valor)
                .ExclusiveBetween(1, 50000).When(x => !x.Gratuito)
                .WithMessage("O valor deve estar entre R$ 1,00 e R$ 50.000,00.");
            else
                RuleFor(x => x.Valor)
                    .Equal(0).When(x => x.Gratuito)
                    .WithMessage("O valor deve ser R$ 0,00 para um Evento Gratuito.");
        }

        private void ValidarData()
        {
            RuleFor(x => x.DataInicio)
                .LessThan(x => x.DataFim)
                .WithMessage("A data de início não deve ser maior que a data final do evento.");

            RuleFor(x => x.DataInicio)
                .GreaterThan(DateTime.Now)
                .WithMessage("A Data de Início não deve ser maior que a data atual.");
        }

        private void ValidarLocal()
        {
            if (Online)
                RuleFor(x => x.Endereco)
                    .Null().When(x => x.Online)
                    .WithMessage("O Evento não deve possuir um endereço se for Online.");
            else
                RuleFor(x => x.Endereco)
                    .NotNull().When(x => !x.Online)
                    .WithMessage("Para um evento presencial, o endereço é obrigatório.");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(x => x.NomeDaEmpresa)
                .NotEmpty().WithMessage("O Nome da Empresa é obrigatório.")
                .Length(3, 150).WithMessage("O Nome da Empresa deve conter entre 3 e 150 caracteres.");
        }

        private void ValidarEndereco()
        {
            if (Online)
                return;
            if (Endereco.IsValid())
                return;
            foreach (var error in Endereco.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);
        }
        #endregion

        #region Factory
        public static class EventoFactory
        {
            public static Evento NovoEventoCompleto(
                Guid id, string nome, string descricaoCurta, string descricaoLonga,
                DateTime dataInicio, DateTime dataFim, bool gratuito, decimal valor,
                bool online, string nomeDaEmpresa, Guid? organizadorId, Endereco endereco, 
                Guid categoriaId)
            {
                var evento = new Evento()
                {
                    Id = id,
                    Nome = nome,
                    DescricaoCurta = descricaoCurta,
                    DescricaoLonga = descricaoLonga,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    Gratuito = gratuito,
                    Valor = valor,
                    Online = online,
                    NomeDaEmpresa = nomeDaEmpresa,
                    Endereco = endereco,
                    CategoriaId = categoriaId,
            };

                if (organizadorId.HasValue)
                    evento.OrganizadorId = organizadorId.Value;

                if (online)
                    evento.Endereco = null;

                return evento;
            }
        }
        #endregion
    }
}
