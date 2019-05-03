using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eventos.IO.Site.Controllers
{
    public class EventosController : BaseController
    {
        private readonly IEventoAppService _eventoAppService;

        public EventosController(IEventoAppService eventoAppService,
                                 IDomainNotificationHandler<DomainNotification> notifications) : base (notifications)
        {
            _eventoAppService = eventoAppService;
        }

        [Route("eventos")]
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

            var mensagemRetorno = OperacaoValida() 
                ? "success,Evento registrado com sucesso!"
                : "error,Evento nao registrado. Verifique!";

            ViewBag.RetornoPost = mensagemRetorno;

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

            var mensagemRetorno = OperacaoValida()
                ? "success,Dados atualizados com sucesso!"
                : "error,Não foi possível atulizar os dados do Evento. Verifique!";

            ViewBag.RetornoPost = mensagemRetorno;

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
