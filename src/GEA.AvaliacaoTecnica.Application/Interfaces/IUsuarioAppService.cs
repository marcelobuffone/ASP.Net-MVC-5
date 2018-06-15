using GEA.AvaliacaoTecnica.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GEA.AvaliacaoTecnica.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterPorUserId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        void Remover(Guid id);
    }
}
