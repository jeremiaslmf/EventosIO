using AutoMapper;
using Eventos.IO.Application.AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eventos.IO.Site.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoAppService _eventoAppService;
        private readonly IMapper _mapper;

        public EventosController(IEventoAppService eventoAppService,
                                 IDomainNotificationHandler<DomainNotification> notifications,
                                 IMapper mapper)
        {
            _eventoAppService = eventoAppService;
            _mapper = mapper;
        }

        [Route("eventos")]
        public IActionResult Index()
        {
            var view = _mapper.Map(new DomainToViewModelMappingProfile(),  new ViewModelToDomainMappingProfile());
            return View(_eventoAppService.ObterTodos());
        }

        [Route("dados-do-evento/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.Value);
            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        [Route("novo-evento")]
        //[Authorize(Policy = "PodeGravar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-evento")]
        //[Authorize(Policy = "PodeGravar")]
        public IActionResult Create(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
                return View(eventoViewModel);

            _eventoAppService.Registrar(eventoViewModel);

            return View(eventoViewModel);
        }

        [Route("eventos/edit/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.Value);
            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("eventos/edit/{id:guid}")]
        public IActionResult Edit(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
                return View(eventoViewModel);

            _eventoAppService.Atualizar(eventoViewModel);

            return View(eventoViewModel);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var eventoViewModel = _eventoAppService.ObterPorId(id.Value);

            if (eventoViewModel == null)
                return NotFound();

            return View(eventoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("eventos/remove/{id:guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _eventoAppService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
