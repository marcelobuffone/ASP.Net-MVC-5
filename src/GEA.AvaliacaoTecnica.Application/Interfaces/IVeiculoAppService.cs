using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IVeiculoAppService : IDisposable
    {
        VeiculoViewModel Adicionar(VeiculoViewModel veiculoViewModel);
        VeiculoViewModel ObterPorId(Guid id);
        IEnumerable<VeiculoViewModel> ObterPorPlaca(string placa);
        IEnumerable<VeiculoViewModel> ObterTodos();
        VeiculoViewModel Atualizar(VeiculoViewModel veiculoViewModel);
        void Remover(Guid id);
    }
}
