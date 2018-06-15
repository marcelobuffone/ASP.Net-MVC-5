using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces.Services
{
    public interface IVeiculoService : IDisposable
    {
        Veiculo Adicionar(Veiculo veiculo);
        Veiculo Atualizar(Veiculo veiculo);
        void Remover(Guid id);
    }
}
