using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class RegistroEntrada : Entity
    {
        public DateTime HoraEntrada { get; set; }
        public string Codigo { get; set; }
        public Guid VeiculoId { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<RegistroSaida> RegistroSaida { get; set; }
    }
}
