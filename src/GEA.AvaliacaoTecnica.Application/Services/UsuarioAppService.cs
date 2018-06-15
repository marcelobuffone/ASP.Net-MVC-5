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
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUsuarioService usuarioAppService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioAppService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioViewModel);
            usuario.Ativo = true;
            _usuarioService.Adicionar(usuario);
            return usuarioViewModel;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioViewModel);
            _usuarioService.Atualizar(usuario);
            return usuarioViewModel;
        }
        IEnumerable<UsuarioViewModel> IUsuarioAppService.ObterPorUserId(Guid id)
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterPorUserId(id));
        }
        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _usuarioService.Remover(id);
        }
        public void Dispose()
        {
            _usuarioRepository.Dispose();
            _usuarioService.Dispose();
        }

    }
}
