using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Domain.Specifications.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
        public Veiculo Adicionar(Veiculo veiculo)
        {
            if (_veiculoRepository.ObterPorPlaca(veiculo.Placa).FirstOrDefault() == null)
            {
                veiculo.Placa = veiculo.Placa.ToUpper().Trim();
                veiculo.Marca = veiculo.Marca.ToUpper().Trim();
                veiculo.Modelo = veiculo.Modelo.ToUpper().Trim();
                _veiculoRepository.Adicionar(veiculo);
            }
            return veiculo;
        }

        public Veiculo Atualizar(Veiculo veiculo)
        {
            return _veiculoRepository.Atualizar(veiculo);
        }

        public void Remover(Guid id)
        {
            _veiculoRepository.Remover(id);
        }
        public void Dispose()
        {
            _veiculoRepository.Dispose();
        }
    }
}
