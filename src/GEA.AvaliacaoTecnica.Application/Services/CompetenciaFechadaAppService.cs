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
    public class CompetenciaFechadaAppService : ICompetenciaFechadaAppService
    {
        private readonly ICompetenciaFechadaRepository _competenciaFechadaRepository;
        private readonly ICompetenciaFechadaService _competenciaFechadaService;

        public CompetenciaFechadaAppService(ICompetenciaFechadaRepository competenciaFechadaRepository
                                            , ICompetenciaFechadaService competenciaFechadaService)
        {
            _competenciaFechadaRepository = competenciaFechadaRepository;
            _competenciaFechadaService = competenciaFechadaService;
        }

        public CompetenciaFechadaViewModel Adicionar(CompetenciaFechadaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaFechada>(competenciaViewModel);
            _competenciaFechadaRepository.Adicionar(competencia);
            return competenciaViewModel;
        }

        public CompetenciaFechadaViewModel Atualizar(CompetenciaFechadaViewModel competenciaViewModel)
        {
            var competencia = Mapper.Map<CompetenciaFechada>(competenciaViewModel);
            _competenciaFechadaRepository.Atualizar(competencia);
            return (competenciaViewModel);
        }


        public CompetenciaFechadaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<CompetenciaFechadaViewModel>(_competenciaFechadaRepository.ObterPorId(id));
        }

        public IEnumerable<CompetenciaFechadaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CompetenciaFechadaViewModel>>(_competenciaFechadaRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _competenciaFechadaRepository.Remover(id);
        }

        public void Dispose()
        {
            _competenciaFechadaRepository.Dispose();
            _competenciaFechadaService.Dispose();
        }
    }
}
