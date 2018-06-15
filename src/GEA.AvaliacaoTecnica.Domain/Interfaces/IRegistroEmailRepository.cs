using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces
{
    public interface IRegistroEmailRepository : IRepository<RegistroEmail>
    {
        IEnumerable<RegistroEmail> ObterPorCompetenciaAbertaId(Guid id);
    }
}
