using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class CompetenciaFechadaService : ICompetenciaFechadaService
    {
        private readonly ICompetenciaFechadaRepository _competenciaFechadaRepository;

        public CompetenciaFechadaService(ICompetenciaFechadaRepository competenciaFechadaRepository)
        {
            _competenciaFechadaRepository = competenciaFechadaRepository;
        }
        public void Dispose()
        {
            _competenciaFechadaRepository.Dispose();
        }
    }
}
