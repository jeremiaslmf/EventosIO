using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Models.Eventos;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models.Organizadores
{
    public class Organizador : Entity<Organizador>
    {

        #region Constructors
        public Organizador(Guid id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
        }

        protected Organizador() { }
        #endregion

        #region Primitive Properties
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }

        // Propriedades de navegação - EF
        public virtual ICollection<Evento> Eventos { get; set; }
        #endregion

        #region Validations
        public override bool IsValid()
        {
            return true;
        }
        #endregion
    }
}