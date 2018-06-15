using DomainValidation.Validation;
using System;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        //public ValidationResult validationResult { get; set; }
        //public abstract bool EhValido();
    }
}
