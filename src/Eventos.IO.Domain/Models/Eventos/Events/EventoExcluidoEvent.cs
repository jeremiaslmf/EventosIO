using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Models.Eventos.Events
{
    public class EventoExcluidoEvent : BaseEventoEvent
    {
        public EventoExcluidoEvent(Guid id)
        {
            Id = AggregateId = id;
        }
    }
}
