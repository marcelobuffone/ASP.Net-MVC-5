using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class RegistroEntradaConfig : EntityTypeConfiguration<RegistroEntrada>
    {
        public RegistroEntradaConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.Codigo).IsRequired().HasMaxLength(50);
            Property(u => u.EmpresaId).IsRequired();
            Property(u => u.DataCadastro).IsRequired();
            Property(u => u.HoraEntrada).IsRequired();
            Property(u => u.VeiculoId).IsRequired();

            HasRequired(e => e.Empresa).WithMany(u => u.Registros).HasForeignKey(e => e.EmpresaId);
            HasRequired(e => e.Veiculo).WithMany(u => u.Registros).HasForeignKey(e => e.VeiculoId);

            ToTable("RegistrosEntrada");
        }
    }
}
