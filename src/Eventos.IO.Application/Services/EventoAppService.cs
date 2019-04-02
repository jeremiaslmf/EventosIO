using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Models.Eventos.Commands;
using Eventos.IO.Domain.Models.Eventos.Repository;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Application.Services
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventoRepository _eventoRepository;

        public EventoAppService(IBus bus, IMapper mapper, IEventoRepository eventoRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _eventoRepository = eventoRepository;
        }

        public void Registrar(EventoViewModel eventoViewModel)
        {
            var registrarCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(registrarCommand);
        }

        public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterEventoPorOrganizador(organizadorId));
        }

        public EventoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.GetById(id));
        }

        public IEnumerable<EventoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.GetAll());
        }

        public void Atualizar(EventoViewModel eventoViewModel)
        {
            // TODO: Validar se o organizador é dono do evento

            var atualizarCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(atualizarCommand);
        }

        public void Excluir(Guid id)
        {
            _bus.SendCommand(new ExcluirEventoCommand(id));
        }

        public void Dispose()
        {
            _eventoRepository.Dispose();
        }
    }
}
