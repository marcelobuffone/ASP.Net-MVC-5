using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.Nome).IsRequired().HasMaxLength(150);
            Property(u => u.EmpresaId).IsRequired();
            Property(u => u.Ativo).IsRequired();
            Property(u => u.DataCadastro).IsRequired();

            HasRequired(e => e.Empresa)
                .WithMany(u => u.Usuarios)
                .HasForeignKey(e => e.EmpresaId);

            ToTable("Usuarios");
        }
    }
}
