using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eventos.IO.Site.Controllers
{
    [Route("")]
    public class EventosController : Controller
    {
        private readonly IEventoAppService _eventoAppService;

        public EventosController(IEventoAppService eventoAppService,
                                 IDomainNotificationHandler<DomainNotification> notifications)
        {
            _eventoAppService = eventoAppService;
        }

        [Route("")]
        [Route("proximos-eventos")]
        public IActionResult Index()
        {
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
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-evento")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create(EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
                return View(eventoViewModel);

            _eventoAppService.Registrar(eventoViewModel);

            return View(eventoViewModel);
        }

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
        public IActionResult DeleteConfirmed(Guid id)
        {
            _eventoAppService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
