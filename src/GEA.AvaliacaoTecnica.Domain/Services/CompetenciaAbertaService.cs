using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class CompetenciaAbertaService : ICompetenciaAbertaService
    {
        private readonly ICompetenciaAbertaRepository _competenciaRepository;
        public CompetenciaAbertaService(ICompetenciaAbertaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public void Dispose()
        {
            _competenciaRepository.Dispose();
        }
    }
}
