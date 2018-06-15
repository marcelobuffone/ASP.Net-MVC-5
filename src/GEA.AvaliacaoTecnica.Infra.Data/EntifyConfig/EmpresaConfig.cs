using GEA.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.RazaoSocial).IsRequired().HasMaxLength(100);
            Property(u => u.Email).IsRequired().HasMaxLength(100);
            Property(u => u.DiaVencimento).IsRequired();
            Property(u => u.DataCadastro).IsRequired();

            ToTable("Empresas");
        }
    }
}
