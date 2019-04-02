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
using Eventos.IO.Infrastructure.Data.Context;
using Eventos.IO.Infrastructure.Data.Repository;
using Eventos.IO.Infrastructure.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.IO.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(m => 
                new Mapper(m.GetRequiredService<IConfigurationProvider>(), m.GetService));
            #endregion

            #region Domain
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();
            #endregion

            #region Infrastructure
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();
            //services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}
