using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GEA.AvaliacaoTecnica.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> ObterPorEmpresa(Guid empresaId)
        {
            return Buscar(u => u.EmpresaId == empresaId);
        }

        public IEnumerable<Usuario> ObterPorUserId(Guid id)
        {
            return Buscar(u => u.UserId == id);
        }
        public override IEnumerable<Usuario> ObterTodos()
        {
            using (var context = new AvaliacaoTecnicaContext())
            {
                var usuarios = context.Usuarios.Include("Empresa").ToList();
                return usuarios;
            }
        }
        public override void Remover(Guid id)
        {
            var usuario = ObterPorId(id);
            usuario.Excluir();
            Atualizar(usuario);
        }
    }
}
