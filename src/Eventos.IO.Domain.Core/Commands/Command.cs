using Eventos.IO.Domain.Core.Events;
using System;

namespace Eventos.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public Command()
        {
            Timestamp = DateTime.Now;
        }

        // Momento em que  o comando foi disparado
        public DateTime Timestamp { get; private set; }
    }
}
