using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IRegistroSaidaAppService : IDisposable
    {
        RegistroSaidaViewModel Adicionar(RegistroSaidaViewModel registroViewModel);
        RegistroSaidaViewModel ObterPorId(Guid id);
        IEnumerable<RegistroSaidaViewModel> ObterTodos();
        IEnumerable<RegistroSaidaViewModel> ObterTodosPorEmpresa(Guid empresaId);
        RegistroSaidaViewModel Atualizar(RegistroSaidaViewModel registroViewModel);
        IEnumerable<RegistroSaidaViewModel> ObterPorIdEntrada(Guid id);
        float ObterTotalBruto(DateTime dataVencimento, Guid idEmpresa);
        void Remover(Guid id);
    }
}
