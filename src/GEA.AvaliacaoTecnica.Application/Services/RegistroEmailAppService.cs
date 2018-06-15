using AutoMapper;
using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Application.Services
{
    public class RegistroEmailAppService : IRegistroEmailAppService
    {
        private readonly IRegistroEmailRepository _registroEmailRepository;
        public RegistroEmailAppService(IRegistroEmailRepository registroEmailRepository)
        {
            _registroEmailRepository = registroEmailRepository;
        }

        public RegistroEmailViewModel Adicionar(RegistroEmailViewModel registroEmailViewModel)
        {
            var registroEmail = Mapper.Map<RegistroEmail>(registroEmailViewModel);
            _registroEmailRepository.Adicionar(registroEmail);
            return registroEmailViewModel;
        }
        public IEnumerable<RegistroEmailViewModel> ObterPorCompetenciaAbertaId(Guid id)
        {
            return Mapper.Map<IEnumerable<RegistroEmailViewModel>>(_registroEmailRepository
                .ObterPorCompetenciaAbertaId(id));
        }

        public RegistroEmailViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RegistroEmailViewModel>(_registroEmailRepository.ObterPorId(id));
        }

        public void Remover(Guid id)
        {
            _registroEmailRepository.Remover(id);
        }
        public void Dispose()
        {
            _registroEmailRepository.Dispose();
        }
    }
}
