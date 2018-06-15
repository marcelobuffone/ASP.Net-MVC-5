using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class RegistroEntradaRepository : Repository<RegistroEntrada>, IRegistroEntradaRepository
    {
        public IEnumerable<RegistroEntrada> ObterTodosPorEmpresa(Guid empresaId)
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var veiculos = context.RegistrosEntrada.Include("Veiculo").Include("RegistroSaida").ToList()
                    .Where(e => e.EmpresaId == empresaId && e.RegistroSaida.FirstOrDefault() == null);
                return veiculos;
            }
        }
    }
}
