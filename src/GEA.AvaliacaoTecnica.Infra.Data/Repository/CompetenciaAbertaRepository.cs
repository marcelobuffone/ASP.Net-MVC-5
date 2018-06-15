using System;
using System.Collections.Generic;
using System.Linq;
using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class CompetenciaAbertaRepository : Repository<CompetenciaAberta>, ICompetenciaAbertaRepository
    {
        public override IEnumerable<CompetenciaAberta> ObterTodos()
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var competencias = context.CompetenciaAberta.Include("Empresa").Include("CompetenciasFechadas").ToList()
                    .Where(e => e.CompetenciasFechadas.FirstOrDefault() == null);
                return competencias;
            }
        }

        public override CompetenciaAberta ObterPorId(Guid id)
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var competencias = context.CompetenciaAberta.Include("Empresa")
                    .Where(e => e.Id == id).FirstOrDefault();
                return competencias;
            }
        }
    }
}
