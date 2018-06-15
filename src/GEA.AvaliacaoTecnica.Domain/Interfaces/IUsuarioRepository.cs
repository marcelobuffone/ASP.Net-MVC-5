using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> ObterPorEmpresa(Guid empresaId);
        IEnumerable<Usuario> ObterPorUserId(Guid id);
    }
}
