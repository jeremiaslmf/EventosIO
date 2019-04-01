using System;
using System.Collections.Generic;
using System.Linq;
using Eventos.IO.Domain.Models.Eventos;
using Eventos.IO.Domain.Models.Eventos.Repository;
using Eventos.IO.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infrastructure.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {

        public EventoRepository(EventosContext context) : base(context)
        {
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return Db.Enderecos.Find(id);
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return Db.Eventos.Where(x => x.OrganizadorId == organizadorId);
        }

        public override Evento GetById(Guid id)
        {
            return Db.Eventos.Include(x=> x.Endereco).FirstOrDefault(x=> x.Id == id);
        }
    }
}
