using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class CompetenciaFechadaRepository : Repository<CompetenciaFechada>, ICompetenciaFechadaRepository
    {
        public override IEnumerable<CompetenciaFechada> ObterTodos()
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var competencias = context.CompetenciaFechada.Include("CompetenciaAberta").Include("CompetenciaAberta.Empresa").ToList();
                return competencias;
            }
        }
    }
}
