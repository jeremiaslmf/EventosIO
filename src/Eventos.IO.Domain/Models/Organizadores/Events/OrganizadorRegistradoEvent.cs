using Eventos.IO.Domain.Core.Events;
using System;

namespace Eventos.IO.Domain.Models.Organizadores.Events
{
    public class OrganizadorRegistradoEvent : Event
    {
        public OrganizadorRegistradoEvent(Guid id, string nome, string cPF, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
    }
}
