using GEA.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class RegistroEmailConfig : EntityTypeConfiguration<RegistroEmail>
    {
        public RegistroEmailConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.CompetenciaAbertaId).IsRequired();
            Property(u => u.texto).IsRequired();
            Property(u => u.titulo).IsRequired();

            HasRequired(e => e.CompetenciaAberta)
                .WithMany(x => x.RegistrosEmails)
                .HasForeignKey(e => e.CompetenciaAbertaId);

            ToTable("RegistrosEmails");
        }
    }
}
