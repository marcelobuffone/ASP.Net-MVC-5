using GEA.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class CompetenciaAbertaConfig : EntityTypeConfiguration<CompetenciaAberta>
    {
        public CompetenciaAbertaConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.DataVencimento).IsRequired();
            Property(u => u.EmpresaId).IsRequired();
            Property(u => u.DataCadastro).IsRequired();

            HasRequired(e => e.Empresa)
                 .WithMany(x => x.CompetenciasAbertas)
                 .HasForeignKey(e => e.EmpresaId);

            ToTable("CompetenciasAbertas");
        }
    }
}
