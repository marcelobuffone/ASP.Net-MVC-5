using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class CompetenciaFechadaConfig : EntityTypeConfiguration<CompetenciaFechada>
    {
        public CompetenciaFechadaConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.ValorBruto).IsRequired();
            Property(u => u.ValorLucro).IsRequired();
            Property(u => u.CompetenciaAbertaId).IsRequired();
            Property(u => u.DataCadastro).IsRequired();

            HasRequired(e => e.CompetenciaAberta)
                .WithMany(x => x.CompetenciasFechadas)
                .HasForeignKey(e => e.CompetenciaAbertaId);

            ToTable("CompetenciasFechadas");
        }
    }
}
