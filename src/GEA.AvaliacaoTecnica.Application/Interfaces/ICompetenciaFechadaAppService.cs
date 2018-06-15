using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface ICompetenciaFechadaAppService : IDisposable
    {
        CompetenciaFechadaViewModel Adicionar(CompetenciaFechadaViewModel competenciaViewModel);
        CompetenciaFechadaViewModel ObterPorId(Guid id);
        IEnumerable<CompetenciaFechadaViewModel> ObterTodos();
        CompetenciaFechadaViewModel Atualizar(CompetenciaFechadaViewModel competenciaViewModel);
        void Remover(Guid id);
    }
}
