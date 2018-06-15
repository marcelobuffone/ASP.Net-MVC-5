using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class RegistroSaidaConfig : EntityTypeConfiguration<RegistroSaida>
    {
        public RegistroSaidaConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.HoraSaida).IsRequired();
            Property(u => u.ValorTotal).IsRequired();
            Property(u => u.RegistroEntradaId).IsRequired();

            HasRequired(e => e.RegistroEntrada).WithMany(x => x.RegistroSaida).HasForeignKey(e => e.RegistroEntradaId);

            ToTable("RegistrosSaida");
        }
    }
}
