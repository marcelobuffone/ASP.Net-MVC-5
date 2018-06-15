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
    public class RegistroSaidaAppService : IRegistroSaidaAppService
    {
        private readonly IRegistroSaidaRepository _registroSaidaRepository;
        private readonly IRegistroSaidaService _registroSaidaService;
        public RegistroSaidaAppService(IRegistroSaidaRepository registroSaidaRepository, IRegistroSaidaService registroSaidaService)
        {
            _registroSaidaRepository = registroSaidaRepository;
            _registroSaidaService = registroSaidaService;
        }
        public RegistroSaidaViewModel Adicionar(RegistroSaidaViewModel registroViewModel)
        {
            var registro = Mapper.Map<RegistroSaida>(registroViewModel);
            _registroSaidaService.Adicionar(registro);
            return registroViewModel;
        }

        public RegistroSaidaViewModel Atualizar(RegistroSaidaViewModel registroViewModel)
        {
            var registro = Mapper.Map<RegistroSaida>(registroViewModel);
            _registroSaidaRepository.Atualizar(registro);
            return registroViewModel;
        }

        public RegistroSaidaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RegistroSaidaViewModel>(_registroSaidaRepository.ObterPorId(id));
        }

        public IEnumerable<RegistroSaidaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RegistroSaidaViewModel>>(_registroSaidaRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _registroSaidaRepository.Remover(id);
        }
        public void Dispose()
        {
            _registroSaidaRepository.Dispose();
            _registroSaidaService.Dispose();
        }

        public IEnumerable<RegistroSaidaViewModel> ObterPorIdEntrada(Guid id)
        {
            return Mapper.Map<IEnumerable<RegistroSaidaViewModel>>(_registroSaidaService.ObterPorIdEntrada(id));
        }
        public IEnumerable<RegistroSaidaViewModel> ObterTodosPorEmpresa(Guid empresaId)
        {
            return Mapper.Map<IEnumerable<RegistroSaidaViewModel>>(_registroSaidaRepository.ObterTodosPorEmpresa(empresaId));
        }

        public float ObterTotalBruto(DateTime dataVencimento, Guid idEmpresa)
        {
            return _registroSaidaRepository.ObterTotalBruto(dataVencimento, idEmpresa);
        }
    }
}
