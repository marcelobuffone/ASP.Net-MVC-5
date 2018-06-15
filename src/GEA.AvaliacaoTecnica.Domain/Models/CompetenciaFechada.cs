using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class CompetenciaFechada : Entity
    {
        public float ValorBruto { get; set; }
        public float ValorLucro { get; set; }
        public Guid CompetenciaAbertaId { get; set; }
        public virtual CompetenciaAberta CompetenciaAberta { get; set; }
    }
}
