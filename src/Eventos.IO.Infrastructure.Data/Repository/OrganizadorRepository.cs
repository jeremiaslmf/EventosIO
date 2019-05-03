using Eventos.IO.Domain.Models.Organizadores;
using Eventos.IO.Domain.Models.Organizadores.Repository;
using Eventos.IO.Infrastructure.Data.Context;

namespace Eventos.IO.Infrastructure.Data.Repository
{
    public class OrganizadorRepository : Repository<Organizador>, IOrganizadorRepository
    {
        public OrganizadorRepository(EventosContext context) : base(context) { }
    }
}
