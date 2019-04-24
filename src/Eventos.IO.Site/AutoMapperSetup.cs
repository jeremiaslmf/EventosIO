using AutoMapper;
using Eventos.IO.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eventos.IO.Presentation.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfiguration.RegisterMappings();
        }
    }
}