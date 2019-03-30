using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Core.Bus
{
    /// <summary>
    /// Disparar comandos
    /// </summary>
    public interface IBus
    {
        // sempre enviado
        void SendCommand<T>(T theCommand) where T : Command;
        // sempre lancado
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
