using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Models.Organizadores.Repository;
using System.Linq;

namespace Eventos.IO.Domain.Models.Organizadores.Commands
{
    public class OrganizadorCommandHandler : CommandHandler, 
        IHandler<RegistrarOrganizadorCommand>
    {
        private readonly IBus _bus;
        private readonly IOrganizadorRepository _organizadorRepository;

        #region Constructor
        public OrganizadorCommandHandler(
            IUnitOfWork uow, 
            IBus bus, 
            IDomainNotificationHandler<DomainNotification> domainNotificationHandler,
            IOrganizadorRepository organizadorRepository) 
            : base(uow, bus, domainNotificationHandler)
        {
            _bus = bus;
            _organizadorRepository = organizadorRepository;
        }
        #endregion

        public void Handle(RegistrarOrganizadorCommand message)
        {
            var organizador = new Organizador(message.Id, message.Nome, message.CPF, message.Email);
            if (!organizador.IsValid())
            {
                NotificarValidacoesErro(organizador.ValidationResult);
                return;
            }

            var isOrganizadorExistente = _organizadorRepository.Find(
                x => x.CPF == organizador.CPF || x.Email == organizador.Email);

            if (isOrganizadorExistente.Any())
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados."));

            _organizadorRepository.Add(organizador);

            if (Commit()) ;
                
        }
    }
}
