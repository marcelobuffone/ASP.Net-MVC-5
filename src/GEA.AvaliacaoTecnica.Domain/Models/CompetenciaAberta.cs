using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class CompetenciaAberta : Entity
    {
        public DateTime DataVencimento { get; set; }
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<CompetenciaFechada> CompetenciasFechadas { get; set; }
        public virtual ICollection<RegistroEmail> RegistrosEmails { get; set; }
    }
}
