using System;

namespace Eventos.IO.Domain.Models.Eventos.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(Guid id, string nome, DateTime datainicio, 
            DateTime dataFim, bool gratuito, decimal valor, bool online, string nomeDaEmpresa)
        {
            Id = id;
            Nome = nome;
            DataInicio = datainicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;

            AggregateId = id;
        }
    }
}
