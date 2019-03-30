using Eventos.IO.Domain.Models.Eventos.Commands;
using System;

namespace Eventos.IO.Domain.Models.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(
        string nome, DateTime datainicio, DateTime dataFim, bool gratuito,
            decimal valor, bool online, string nomeDaEmpresa)
        {
            Nome = nome;
            DataInicio = datainicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
            NomeDaEmpresa = nomeDaEmpresa;
        }
    }
}
