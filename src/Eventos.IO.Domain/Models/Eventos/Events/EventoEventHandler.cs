using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Models.Eventos.Events;
using System;

namespace Eventos.IO.Domain.Models.Eventos.Events
{
    /// <summary>
    /// Classe de manipulação de eventos
    /// </summary>
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Registrado com sucesso!");
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Atualizado com sucesso!");
        }

        public void Handle(EventoExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Excluido com sucesso!");
        }
    }
}
