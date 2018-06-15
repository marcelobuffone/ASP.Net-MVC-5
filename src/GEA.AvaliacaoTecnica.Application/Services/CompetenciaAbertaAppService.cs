using AutoMapper;
using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Services
{
    public class CompetenciaAbertaAppService : ICompetenciaAbertaAppService
    {
        private readonly ICompetenciaAbertaRepository _competenciaRepository;
        private readonly ICompetenciaAbertaService _competenciaService;

        public CompetenciaAbertaAppService(ICompetenciaAbertaRepository competenciaRepository, ICompetenciaAbertaService competenciaService)
        {
            _competenciaRepository= competenciaRepository;
            _competenciaService = competenciaService;
        }
        public CompetenciaAberturaViewModel Adicionar(CompetenciaAberturaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaAberta>(competenciaViewModel);
            _competenciaRepository.Adicionar(competencia);
            return competenciaViewModel;
        }

        public CompetenciaAberturaViewModel Atualizar(CompetenciaAberturaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaAberta>(competenciaViewModel);
            _competenciaRepository.Atualizar(competencia);
            return competenciaViewModel;
        }

        public CompetenciaAberturaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<CompetenciaAberturaViewModel>(_competenciaRepository.ObterPorId(id));
        }

        public IEnumerable<CompetenciaAberturaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CompetenciaAberturaViewModel>>(_competenciaRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _competenciaRepository.Remover(id);
        }

        public void Dispose()
        {
            _competenciaRepository.Dispose();
            _competenciaService.Dispose();
        }
    }
}
