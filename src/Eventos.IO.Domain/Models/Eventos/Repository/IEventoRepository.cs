using Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models.Eventos.Repository
{
    public interface IEventoRepository : IRepository<Evento>
    {
        // Implementação dos métodos especializados
        IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);
        Endereco ObterEnderecoPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
    }
}
