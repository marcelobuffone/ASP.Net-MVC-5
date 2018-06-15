using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class Veiculo : Entity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public virtual ICollection<RegistroEntrada> Registros { get; set; }

    }
}
