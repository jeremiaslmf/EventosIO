using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Models.Eventos.Commands;
using System;

namespace Eventos.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Registrar
            CreateMap<EventoViewModel, RegistrarEventoCommand>()
                .ConstructUsing(c => new RegistrarEventoCommand(
                    c.Nome,
                    c.DescricaoCurta,
                    c.DescricaoLonga,
                    c.DataInicio,
                    c.DataFim,
                    c.Gratuito,
                    c.Valor,
                    c.Online,
                    c.NomeDaEmpresa,
                    c.CategoriaId,
                    c.OrganizadorId,
                    new IncluirEnderecoEventoCommand(
                        c.Endereco.Id,
                        c.Endereco.Logradouro,
                        c.Endereco.Numero,
                        c.Endereco.Complemento,
                        c.Endereco.Bairro,
                        c.Endereco.CEP,
                        c.Endereco.Cidade,
                        c.Endereco.Estado,
                        c.Endereco.Id)));

            //CreateMap<EnderecoViewModel, IncluirEnderecoEventoCommand>()
            //   .ConstructUsing(c => new IncluirEnderecoEventoCommand(
            //       Guid.NewGuid(), 
            //       c.Logradouro, 
            //       c.Numero, 
            //       c.Complemento, 
            //       c.Bairro, 
            //       c.CEP, 
            //       c.Cidade, 
            //       c.Estado, 
            //       c.EventoId));

            //#endregion

            //#region Atualizar
            //CreateMap<EventoViewModel, AtualizarEventoCommand>()
            //    .ConstructUsing(c => new AtualizarEventoCommand(
            //        c.Id,
            //        c.Nome,
            //        c.DescricaoCurta,
            //        c.DescricaoLonga,
            //        c.DataInicio,
            //        c.DataFim,
            //        c.Gratuito,
            //        c.Valor,
            //        c.Online,
            //        c.NomeDaEmpresa,
            //        c.CategoriaId,
            //        c.OrganizadorId));
            //#endregion

            //#region Excluir
            //CreateMap<EventoViewModel, ExcluirEventoCommand>()
            //    .ConstructUsing(c => new ExcluirEventoCommand(c.Id));
            #endregion
        }
    }
}
