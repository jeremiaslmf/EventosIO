﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.IO.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        #region Constructor
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }
        #endregion

        #region Properties
        public Guid Id { get; protected set; }

        [NotMapped] // Para não dar problemas com mapeamento EF
        public ValidationResult ValidationResult { get; protected set; }
        #endregion

        #region Methods
        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id = {Id}]";
        }
        #endregion
    }
}
