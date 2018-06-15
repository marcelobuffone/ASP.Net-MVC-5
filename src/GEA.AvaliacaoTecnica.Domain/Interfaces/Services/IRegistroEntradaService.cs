using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces.Services
{
    public interface IRegistroEntradaService : IDisposable
    {
        RegistroEntrada Adicionar(RegistroEntrada registro);
        RegistroEntrada Atualizar(RegistroEntrada registro);
        IEnumerable<RegistroEntrada> ObterPorCodigo(string codigo);

    }
}
