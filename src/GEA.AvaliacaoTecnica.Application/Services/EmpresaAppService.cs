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
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaService _empresaService;


        public EmpresaAppService(IEmpresaRepository empresaRepository, IEmpresaService empresaService)
        {
            _empresaRepository = empresaRepository;
            _empresaService = empresaService;
        }
        public EmpresaViewModel Adicionar(EmpresaViewModel empresaViewModel)
        {
            var empresa = Mapper.Map<Empresa>(empresaViewModel);
            _empresaService.Adicionar(empresa);
            return empresaViewModel;
        }

        public EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel)
        {
            var empresa = Mapper.Map<Empresa>(empresaViewModel);
            _empresaService.Atualizar(empresa);
            return empresaViewModel;
        }

        public EmpresaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.ObterPorId(id));
        }

        public IEnumerable<EmpresaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EmpresaViewModel>>(_empresaRepository.ObterTodos());
        }
        public IEnumerable<EmpresaViewModel> ObterPorRazaoSocial(string razaoSocial)
        {
            return Mapper.Map<IEnumerable<EmpresaViewModel>>(_empresaService.ObterPorRazaoSocial(razaoSocial));
        }
        public void Remover(Guid id)
        {
            _empresaService.Remover(id);
        }
        public void Dispose()
        {
            _empresaRepository.Dispose();
            _empresaService.Dispose();
        }
    }
}
