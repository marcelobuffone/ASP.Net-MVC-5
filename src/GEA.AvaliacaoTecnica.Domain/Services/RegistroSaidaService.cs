using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class RegistroSaidaService : IRegistroSaidaService
    {
        private readonly IRegistroSaidaRepository _registroSaidaRepository;
        public RegistroSaidaService(IRegistroSaidaRepository registroSaidaRepository)
        {
            _registroSaidaRepository = registroSaidaRepository;
        }
        public RegistroSaida Adicionar(RegistroSaida registro)
        {
            registro.HoraSaida = DateTime.Now;
            return _registroSaidaRepository.Adicionar(registro);
        }

        public IEnumerable<RegistroSaida> ObterPorIdEntrada(Guid id)
        {
            return _registroSaidaRepository.Buscar(r => r.RegistroEntradaId == id);
        }
        public void Dispose()
        {
            _registroSaidaRepository.Dispose();
        }
    }
}
