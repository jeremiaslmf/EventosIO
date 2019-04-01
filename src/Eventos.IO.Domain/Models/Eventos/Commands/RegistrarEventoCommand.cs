using System;

namespace Eventos.IO.Domain.Models.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(string nome, string descricaoCurta, string descricaoLonga, 
            DateTime datainicio, DateTime dataFim, bool gratuito, decimal valor, bool online, 
            string nomeDaEmpresa, Guid categoriaId, Guid organizadorId, 
            IncluirEnderecoEventoCommand incluirEnderecoEventoCommand)
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataInicio = datainicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;
            CategoriaId = categoriaId;
            OrganizadorId = organizadorId;
            Endereco = incluirEnderecoEventoCommand;
        }

        public IncluirEnderecoEventoCommand Endereco { get; private set; }
    }
}
