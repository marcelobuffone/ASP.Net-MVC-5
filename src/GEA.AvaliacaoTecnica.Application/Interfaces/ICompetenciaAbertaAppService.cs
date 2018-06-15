using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface ICompetenciaAbertaAppService : IDisposable
    {
        CompetenciaAberturaViewModel Adicionar(CompetenciaAberturaViewModel competenciaViewModel);
        CompetenciaAberturaViewModel ObterPorId(Guid id);
        IEnumerable<CompetenciaAberturaViewModel> ObterTodos();
        CompetenciaAberturaViewModel Atualizar(CompetenciaAberturaViewModel competenciaViewModel);
        void Remover(Guid id);
    }
}
