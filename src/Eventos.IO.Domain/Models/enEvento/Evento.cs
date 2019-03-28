using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Models.enCategoria;
using Eventos.IO.Domain.Models.enEndereco;
using Eventos.IO.Domain.Models.enOrganizdor;
using Eventos.IO.Domain.Models.enTag;
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
    }
}
