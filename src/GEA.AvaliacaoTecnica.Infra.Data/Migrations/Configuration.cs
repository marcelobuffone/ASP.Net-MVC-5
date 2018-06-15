namespace GEA.AvaliacaoTecnica.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GEA.AvaliacaoTecnica.Infra.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.AvaliacaoTecnicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.AvaliacaoTecnicaContext context)
        {

        }
    }
}
