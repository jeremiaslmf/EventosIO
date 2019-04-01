using Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Models.Eventos
{
    public class Categoria : Entity<Categoria>
    {
        #region Constructor
        public Categoria(Guid id)
        {
            Id = id;
        }

        protected Categoria() { }
        #endregion

        #region Properties
        public string Nome { get; private set; }

        // Propriedades de Navegação - EF
        public virtual ICollection<Evento> Eventos { get; private set; }
        #endregion

        #region Validations
        public override bool IsValid()
        {
            return true;
        }
        #endregion
    }
}