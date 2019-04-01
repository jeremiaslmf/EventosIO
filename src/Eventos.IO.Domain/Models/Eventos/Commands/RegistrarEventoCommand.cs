using System;

namespace Eventos.IO.Domain.Models.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(
        string nome, DateTime datainicio, DateTime dataFim, bool gratuito,
            decimal valor, bool online, string nomeDaEmpresa, Endereco endereco,
            Guid categoriaId, Guid organizadorId)
        {
            Nome = nome;
            DataInicio = datainicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;
            Endereco = endereco;
            CategoriaId = categoriaId;
            OrganizadorId = organizadorId;
        }
    }
}
