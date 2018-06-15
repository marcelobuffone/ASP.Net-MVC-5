using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces.Services
{
    public interface IEmpresaService :IDisposable
    {
        Empresa Adicionar(Empresa empresa);
        Empresa Atualizar(Empresa empresa);
        IEnumerable<Empresa> ObterPorRazaoSocial(string razaoSocial);
        void Remover(Guid id);
    }
}
