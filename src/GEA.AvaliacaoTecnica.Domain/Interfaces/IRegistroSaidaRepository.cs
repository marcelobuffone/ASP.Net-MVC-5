using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces
{
    public interface IRegistroSaidaRepository : IRepository<RegistroSaida>
    {
        IEnumerable<RegistroSaida> ObterTodosPorEmpresa(Guid empresaId);
        float ObterTotalBruto(DateTime dataVencimento, Guid idEmpresa);
    }
}
