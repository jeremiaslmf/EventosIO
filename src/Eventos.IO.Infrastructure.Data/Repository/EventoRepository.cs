using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Eventos.IO.Domain.Models.Eventos;
using Eventos.IO.Domain.Models.Eventos.Repository;
using Eventos.IO.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infrastructure.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        private string _sql = string.Empty;

        public EventoRepository(EventosContext context) : base(context) { }

        public override IEnumerable<Evento> GetAll()
        {
            _sql = "SELECT * FROM EVENTOS E " +
                   "WHERE E.EXCLUIDO = 0 " +
                   "ORDER BY E.DATAFIM DESC";

            return Db.Database.GetDbConnection().Query<Evento>(_sql);
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
            _sql = @"SELECT * FROM Enderecos E " +
                    "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(_sql, new { uid = id });

            return endereco.SingleOrDefault();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            _sql = @"SELECT * FROM Eventos E " +
                    "WHERE E.EXCLUIDO = 0 AND E.ORGANIZADORID = @oid " +
                    "ORDER BY E.DATAFIM DESC";

            var evento = Db.Database.GetDbConnection().Query<Evento>(_sql, new { oid = organizadorId });
            return evento;
        }

        public override Evento GetById(Guid id)
        {
            _sql = @"SELECT * FROM Eventos E " +
                    "LEFT JOIN Enderecos EN ON E.Id = EN.EventoId " +
                    "WHERE E.Id = @uid";

             var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(_sql,
                (ev, en) =>
                {
                    if (en != null)
                        ev.AtribuirEndereco(en);
                    return ev;
                }, new { uid = id });

            return evento.FirstOrDefault();
        }
    }
}
