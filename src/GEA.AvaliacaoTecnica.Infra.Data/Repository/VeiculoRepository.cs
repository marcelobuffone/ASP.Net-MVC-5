using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public IEnumerable<Veiculo> ObterPorPlaca(string placa)
        {
            return Buscar(v => v.Placa == placa);
        }
    }
}
