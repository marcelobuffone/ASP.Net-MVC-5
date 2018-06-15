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
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoService _veiculoService;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, IVeiculoService veiculoService)
        {
            _veiculoRepository = veiculoRepository;
            _veiculoService = veiculoService;
        }

        public VeiculoViewModel Adicionar(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = Mapper.Map<Veiculo>(veiculoViewModel);
            _veiculoService.Adicionar(veiculo);
            return veiculoViewModel;
        }

        public VeiculoViewModel Atualizar(VeiculoViewModel veiculoViewModel)
        {
            var veiculo = Mapper.Map<Veiculo>(veiculoViewModel);
            _veiculoService.Atualizar(veiculo);
            return veiculoViewModel;
        }

        public VeiculoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<VeiculoViewModel>(_veiculoRepository.ObterPorId(id));
        }

        public IEnumerable<VeiculoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<VeiculoViewModel>>(_veiculoRepository.ObterTodos());
        }

        public IEnumerable<VeiculoViewModel> ObterPorPlaca(string placa)
        {
            return Mapper.Map<IEnumerable<VeiculoViewModel>>(_veiculoRepository.ObterPorPlaca(placa)) ;
        }

        public void Remover(Guid id)
        {
            _veiculoService.Remover(id);
        }

        public void Dispose()
        {
            _veiculoService.Dispose();
            _veiculoRepository.Dispose();
        }


    }
}
