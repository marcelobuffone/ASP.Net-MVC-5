using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaViewModel Adicionar(EmpresaViewModel empresaViewModel);
        EmpresaViewModel ObterPorId(Guid id);
        IEnumerable<EmpresaViewModel> ObterTodos();
        IEnumerable<EmpresaViewModel> ObterPorRazaoSocial(string razaoSocial);
        EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel);
        void Remover(Guid id);
    }
}
