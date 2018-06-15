using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces
{
    public interface IRegistroEntradaRepository : IRepository<RegistroEntrada>
    {
        IEnumerable<RegistroEntrada> ObterTodosPorEmpresa(Guid empresaId);
    }
}
