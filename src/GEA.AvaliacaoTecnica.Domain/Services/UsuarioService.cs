using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario Adicionar(Usuario usuario)
        {
            return _usuarioRepository.Adicionar(usuario);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            return _usuarioRepository.Atualizar(usuario);
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
