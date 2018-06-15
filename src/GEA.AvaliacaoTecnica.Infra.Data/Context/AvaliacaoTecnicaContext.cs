using GEA.AvaliacaoTecnica.Domain.Models;
using GEA.AvaliacaoTecnica.Infra.Data.EntifyConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.Infra.Data.Context
{
    public class AvaliacaoTecnicaContext : DbContext
    {
        public AvaliacaoTecnicaContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<RegistroEntrada> RegistrosEntrada { get; set; }
        public DbSet<RegistroSaida> RegistrosSaida { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<CompetenciaAberta> CompetenciaAberta { get; set; }
        public DbSet<CompetenciaFechada> CompetenciaFechada { get; set; }
        public DbSet<RegistroEmail> RegistroEmail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CompetenciaAbertaConfig());
            modelBuilder.Configurations.Add(new CompetenciaFechadaConfig());
            modelBuilder.Configurations.Add(new EmpresaConfig());
            modelBuilder.Configurations.Add(new RegistroEntradaConfig());
            modelBuilder.Configurations.Add(new RegistroSaidaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VeiculoConfig());
            modelBuilder.Configurations.Add(new RegistroEmailConfig());
            //Database.SetInitializer<AvaliacaoTecnicaContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();  
        }
    }
}
