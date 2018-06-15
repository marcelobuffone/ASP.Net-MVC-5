using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IRegistroEmailAppService : IDisposable
    {
        RegistroEmailViewModel Adicionar(RegistroEmailViewModel registroEmailViewModel);
        RegistroEmailViewModel ObterPorId(Guid id);
        IEnumerable<RegistroEmailViewModel> ObterPorCompetenciaAbertaId(Guid id);
        void Remover(Guid id);
    }
}
