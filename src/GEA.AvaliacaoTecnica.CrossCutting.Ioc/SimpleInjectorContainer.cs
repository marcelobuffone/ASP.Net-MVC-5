using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.Services;
using GEA.AvaliacaoTecnica.Domain.Interfaces;
using GEA.AvaliacaoTecnica.Domain.Interfaces.Services;
using GEA.AvaliacaoTecnica.Domain.Services;
using GEA.AvaliacaoTecnica.Infra.Data.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEA.AvaliacaoTecnica.CrossCutting.Ioc
{
    public class SimpleInjectorContainer
    {
        public static void Register(Container container)
        {
            //APP
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IEmpresaAppService, EmpresaAppService>(Lifestyle.Scoped);
            container.Register<IVeiculoAppService, VeiculoAppService>(Lifestyle.Scoped);
            container.Register<IRegistroEntradaAppService, RegistroEntradaAppService>(Lifestyle.Scoped);
            container.Register<IRegistroSaidaAppService, RegistroSaidaAppService>(Lifestyle.Scoped);
            container.Register<ICompetenciaAbertaAppService, CompetenciaAbertaAppService>(Lifestyle.Scoped);
            container.Register<ICompetenciaFechadaAppService, CompetenciaFechadaAppService>(Lifestyle.Scoped);
            container.Register<IRegistroEmailAppService, RegistroEmailAppService>(Lifestyle.Scoped);

            //DOMAIN
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IEmpresaService, EmpresaService>(Lifestyle.Scoped);
            container.Register<IVeiculoService, VeiculoService>(Lifestyle.Scoped);
            container.Register<IRegistroEntradaService, RegistroEntradaService>(Lifestyle.Scoped);
            container.Register<IRegistroSaidaService, RegistroSaidaService>(Lifestyle.Scoped);
            container.Register<ICompetenciaAbertaService, CompetenciaAbertaService>(Lifestyle.Scoped);
            container.Register<ICompetenciaFechadaService, CompetenciaFechadaService>(Lifestyle.Scoped);

            //INFRA
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IEmpresaRepository, EmpresaRepository>(Lifestyle.Scoped);
            container.Register<IVeiculoRepository, VeiculoRepository>(Lifestyle.Scoped);
            container.Register<IRegistroEntradaRepository, RegistroEntradaRepository>(Lifestyle.Scoped);
            container.Register<IRegistroSaidaRepository, RegistroSaidaRepository>(Lifestyle.Scoped);
            container.Register<ICompetenciaAbertaRepository, CompetenciaAbertaRepository>(Lifestyle.Scoped);
            container.Register<ICompetenciaFechadaRepository, CompetenciaFechadaRepository>(Lifestyle.Scoped);
            container.Register<IRegistroEmailRepository, RegistroEmailRepository>(Lifestyle.Scoped);

        }
    }
}
