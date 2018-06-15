using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class RegistroSaidaRepository : Repository<RegistroSaida>, IRegistroSaidaRepository
    {
        public IEnumerable<RegistroSaida> ObterTodosPorEmpresa(Guid empresaId)
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var veiculos = context.RegistrosSaida.Include("RegistroEntrada").Include("RegistroEntrada.Veiculo").ToList().Where(e => e.RegistroEntrada.EmpresaId == empresaId);
                return veiculos;
            }
        }

        public float ObterTotalBruto(DateTime dataVencimento, Guid idEmpresa)
        {
            var dataVencimentoAnterior = new DateTime(dataVencimento.AddMonths(-1).Year, dataVencimento.AddMonths(-1).Month, dataVencimento.Day) + new TimeSpan(00, 00, 01);

            using (var context = new AvaliacaoTecnicaContext())
            {
                var registrosSaida = context.RegistrosSaida.Include("RegistroEntrada").Include("RegistroEntrada.Empresa").ToList()
                    .Where(e => e.HoraSaida <= dataVencimento
                    && e.HoraSaida >= dataVencimentoAnterior
                    && e.RegistroEntrada.EmpresaId == idEmpresa);

                float valorTotal = 0;
                foreach (var item in registrosSaida)
                {
                    valorTotal += item.ValorTotal;
                }
                return valorTotal;
            }
        }
    }
}
