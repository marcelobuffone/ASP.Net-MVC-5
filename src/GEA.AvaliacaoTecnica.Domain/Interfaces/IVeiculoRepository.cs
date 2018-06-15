using GEA.AvaliacaoTecnica.Domain.Models;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        IEnumerable<Veiculo> ObterPorPlaca(string placa);
    }
}
