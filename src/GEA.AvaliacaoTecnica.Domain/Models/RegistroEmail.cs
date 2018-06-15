using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class RegistroEmail : Entity
    {
        public string texto { get; set; }
        public string titulo { get; set; }
        public Guid CompetenciaAbertaId { get; set; }
        public virtual CompetenciaAberta CompetenciaAberta { get; set; }
    }
}
