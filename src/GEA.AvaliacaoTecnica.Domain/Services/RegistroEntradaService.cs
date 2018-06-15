using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEA.AvaliacaoTecnica.Domain.Models;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class RegistroEntradaService : IRegistroEntradaService
    {
        private readonly IRegistroEntradaRepository _registroRepository;
        public RegistroEntradaService(IRegistroEntradaRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        public RegistroEntrada Adicionar(RegistroEntrada registro)
        {
            registro.HoraEntrada = DateTime.Now;
            return _registroRepository.Adicionar(registro);
        }

        public RegistroEntrada Atualizar(RegistroEntrada registro)
        {

            return _registroRepository.Atualizar(registro);
        }

        public void Dispose()
        {
            _registroRepository.Dispose();
        }

        public IEnumerable<RegistroEntrada> ObterPorCodigo(string codigo)
        {
            return _registroRepository.Buscar(r => r.Codigo == codigo);
        }


    }
}
