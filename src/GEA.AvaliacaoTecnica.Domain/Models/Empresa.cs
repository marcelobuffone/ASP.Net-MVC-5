using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class Empresa : Entity
    {
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public int DiaVencimento { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<RegistroEntrada> Registros { get; set; }
        public virtual ICollection<CompetenciaAberta> CompetenciasAbertas { get; set; }
    }
}
 