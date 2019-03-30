using Eventos.IO.Domain.Core.Events;
using System;

namespace Eventos.IO.Domain.Models.Eventos.Events
{
    public class BaseEventoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string DescricaoCurta { get; protected set; }
        public string DescricaoLonga { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataFim { get; protected set; }
        public bool Gratuito { get; protected set; }
        public decimal Valor { get; protected set; }
        public bool Online { get; protected set; }
        public string NomeDaEmpresa { get; protected set; }
    }
}
