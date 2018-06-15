using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class RegistroEmailRepository : Repository<RegistroEmail>, IRegistroEmailRepository
    {
        public IEnumerable<RegistroEmail> ObterPorCompetenciaAbertaId(Guid id)
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var registrosEmails = context.RegistroEmail.Include("CompetenciaAberta")
                    .Where(x => x.CompetenciaAberta.Id == id).ToList();
                return registrosEmails;
            }
        }
    }
}
