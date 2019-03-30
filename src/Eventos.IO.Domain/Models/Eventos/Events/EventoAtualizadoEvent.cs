using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Models.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(Guid id, string nome, string descricaoCurta,
            string descricaoLonga, DateTime datainicio, DateTime dataFim, bool gratuito,
            decimal valor, bool online, string nomeDaEmpresa)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
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
