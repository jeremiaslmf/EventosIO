﻿using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;

namespace Eventos.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(
            IUnitOfWork uow, 
            IBus bus, 
            IDomainNotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _uow = uow;
            _bus = bus;
            _notifications = domainNotificationHandler;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _bus.RaiseEvent(
                    new DomainNotification(error.PropertyName, error.ErrorMessage));
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            var commandResponse = _uow.Commit();
            if (!commandResponse.Success)
                _bus.RaiseEvent(
                    new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados."));

            return commandResponse.Success;
        }
    }
}
