using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;
namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IRegistroEntradaAppService : IDisposable
    {
        RegistroEntradaViewModel Adicionar(RegistroEntradaViewModel registroViewModel);
        RegistroEntradaViewModel ObterPorId(Guid id);
        IEnumerable<RegistroEntradaViewModel> ObterTodos();
        IEnumerable<RegistroEntradaViewModel> ObterTodosPorEmpresa(Guid empresaId);
        IEnumerable<RegistroEntradaViewModel> ObterPorCodigo(string codigo);
        RegistroEntradaViewModel Atualizar(RegistroEntradaViewModel registroViewModel);
        void Remover(Guid id);
    }
}
