using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Domain.Interfaces.Services
{
    public interface IUsuarioService :  IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        void Remover(Guid id);
    }
}
