using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.Services;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Models.Eventos.Commands;
using Eventos.IO.Domain.Models.Eventos.Events;
using Eventos.IO.Domain.Models.Eventos.Repository;
using Eventos.IO.Domain.Models.Organizadores.Commands;
using Eventos.IO.Domain.Models.Organizadores.Events;
using Eventos.IO.Domain.Models.Organizadores.Repository;
using Eventos.IO.Infrastructure.CrossCutting.Bus;
using Eventos.IO.Infrastructure.Data.Context;
using Eventos.IO.Infrastructure.Data.Repository;
using Eventos.IO.Infrastructure.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.IO.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region AspNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Application
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IOrganizadorAppService, OrganizadorAppService>();
            #endregion

            #region Domain
            // Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RegistrarOrganizadorCommand>, OrganizadorCommandHandler>();
            // Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();
            //Organizador
            services.AddScoped<IHandler<OrganizadorRegistradoEvent>, OrganizadorEventHandler>();
            #endregion

            #region Infrastructure
            // Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();
            // Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}
