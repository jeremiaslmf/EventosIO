using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Models.Eventos;
using Eventos.IO.Domain.Models.Organizadores;

namespace Eventos.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Organizador, OrganizadorViewModel>(); 
        }
    }
}
