using System;

namespace GEA.AvaliacaoTecnica.Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid UserId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public void Excluir()
        {
            Ativo = false;
        }

    }
}
