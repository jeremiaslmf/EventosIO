using Eventos.IO.Domain.Core.Events;

namespace Eventos.IO.Domain.Models.Organizadores.Events
{
    public class OrganizadorEventHandler : IHandler<OrganizadorRegistradoEvent>
    {
        public void Handle(OrganizadorRegistradoEvent message)
        {
            // Todo : Enviar o email de notificacao
        }
    }
}
