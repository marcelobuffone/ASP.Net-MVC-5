using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces.Services
{
    public interface IRegistroSaidaService : IDisposable
    {
        RegistroSaida Adicionar(RegistroSaida registro);

        IEnumerable<RegistroSaida> ObterPorIdEntrada(Guid id);

    }
}
