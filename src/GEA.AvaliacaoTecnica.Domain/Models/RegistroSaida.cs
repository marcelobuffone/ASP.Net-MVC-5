using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class RegistroSaida : Entity
    {
        public DateTime HoraSaida { get; set; }
        public float ValorTotal { get; set; }
        public Guid RegistroEntradaId { get; set; }
        public virtual RegistroEntrada RegistroEntrada {get; set;}
    }
}
