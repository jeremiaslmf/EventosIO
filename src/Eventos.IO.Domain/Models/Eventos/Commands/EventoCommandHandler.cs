using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Models.Eventos.Events;
using Eventos.IO.Domain.Models.Eventos.Repository;
using System;
using static Eventos.IO.Domain.Models.Eventos.Evento;

namespace Eventos.IO.Domain.Models.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;

        public EventoCommandHandler(
            IUnitOfWork uow,
            IBus bus,
            IEventoRepository eventoRepository,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var endereco = new Endereco(message.Id, message.Endereco.Logradouro, message.Endereco.Numero,
            message.Endereco.Complemento, message.Endereco.Bairro, message.Endereco.CEP, message.Endereco.Cidade,
            message.Endereco.Estado, message.Id);

            var evento = EventoFactory.NovoEventoCompleto(message.Id, message.Nome,
                message.DescricaoCurta, message.DescricaoLonga, message.DataInicio,
                message.DataFim, message.Gratuito, message.Valor, message.Online,
                message.NomeDaEmpresa, message.OrganizadorId, endereco, message.CategoriaId);

            if (!EventoValido(evento))
                return;

            // Validações de Negócio
            _eventoRepository.Add(evento);

            // Persistência
            if (Commit())
            {
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome,
                    evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor,
                    evento.Online, evento.NomeDaEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var eventoAtual = _eventoRepository.GetById(message.Id);

            if (!EventoExistente(message.Id, message.MessageType))
                return;

            var evento = EventoFactory.NovoEventoCompleto(message.Id, message.Nome,
                 message.DescricaoCurta, message.DescricaoLonga, message.DataInicio,
                 message.DataFim, message.Gratuito, message.Valor, message.Online,
                 message.NomeDaEmpresa, message.OrganizadorId, eventoAtual.Endereco,
                 message.CategoriaId);

            if (!EventoValido(evento))
                return;

            _eventoRepository.Update(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoAtualizadoEvent(message.Id, message.Nome,
                message.DescricaoCurta, message.DescricaoLonga, message.DataInicio,
                message.DataFim, message.Gratuito, message.Valor, message.Online,
                message.NomeDaEmpresa));
            }
        }

        public void Handle(ExcluirEventoCommand message)
        {
            if (!EventoExistente(message.Id, message.MessageType))
                return;

            _eventoRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
        }

        private bool EventoValido(Evento evento)
        {
            if (!evento.IsValid())
                NotificarValidacoesErro(evento.ValidationResult);
            return evento.IsValid();
        }

        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.GetById(id);

            if (evento == null)
                _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado."));

            return evento != null;
        }
    }
}
