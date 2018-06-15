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
    public class RegistroEntradaAppService : IRegistroEntradaAppService
    {
        private readonly IRegistroEntradaRepository _registroEntradaRepository;
        private readonly IRegistroEntradaService _registroEntradaService;
        public RegistroEntradaAppService(IRegistroEntradaRepository registroEntradaRepository, IRegistroEntradaService registroEntradaService)
        {
            _registroEntradaRepository = registroEntradaRepository;
            _registroEntradaService = registroEntradaService;
        }

        public RegistroEntradaViewModel Adicionar(RegistroEntradaViewModel registroViewModel)
        {
            var registro = Mapper.Map<RegistroEntrada>(registroViewModel);
            _registroEntradaService.Adicionar(registro);
            return registroViewModel;
        }

        public RegistroEntradaViewModel Atualizar(RegistroEntradaViewModel registroViewModel)
        {
            var registro = Mapper.Map<RegistroEntrada>(registroViewModel);
            _registroEntradaService.Atualizar(registro);
            return registroViewModel;
        }

        public RegistroEntradaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RegistroEntradaViewModel>(_registroEntradaRepository.ObterPorId(id));
        }

        public IEnumerable<RegistroEntradaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RegistroEntradaViewModel>>(_registroEntradaRepository.ObterTodos());
        }
        public IEnumerable<RegistroEntradaViewModel> ObterTodosPorEmpresa(Guid empresaId)
        {
            return Mapper.Map<IEnumerable<RegistroEntradaViewModel>>(_registroEntradaRepository.ObterTodosPorEmpresa(empresaId));
        }
        public void Remover(Guid id)
        {
            _registroEntradaRepository.Remover(id);
        }
        public void Dispose()
        {
            _registroEntradaRepository.Dispose();
            _registroEntradaService.Dispose();
        }

        public IEnumerable<RegistroEntradaViewModel> ObterPorCodigo(string codigo)
        {
            return Mapper.Map<IEnumerable<RegistroEntradaViewModel>>(_registroEntradaService.ObterPorCodigo(codigo));
        }
    }
}
