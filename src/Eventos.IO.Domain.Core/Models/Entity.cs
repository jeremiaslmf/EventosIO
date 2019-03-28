using System;

namespace Eventos.IO.Domain.Core.Models
{
    public abstract class Entity<T>
    {
        public Guid Id { get; protected set; }
    }
}
