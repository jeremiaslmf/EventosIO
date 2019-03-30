using Eventos.IO.Domain.Core.Models;
using System;

namespace Eventos.IO.Domain.Models.Organizadores
{
    public class Organizador : Entity<Organizador>
    {
        public Organizador(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}