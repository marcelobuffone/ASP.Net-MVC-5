using GEA.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig
{
    public class VeiculoConfig : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoConfig()
        {
            HasKey(u => u.Id);
            Property(u => u.Placa).IsRequired().HasMaxLength(100);
            Property(u => u.Modelo).IsRequired().HasMaxLength(100);
            Property(u => u.Marca).IsRequired();
            Property(u => u.DataCadastro).IsRequired();

            ToTable("Veiculos");
        }
    }
}
