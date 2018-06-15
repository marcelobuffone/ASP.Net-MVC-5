[assembly: WebActivator.PostApplicationStartMethod(typeof(GEA.AvaliacaoTecnica.Presentation.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace GEA.AvaliacaoTecnica.Presentation.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using GEA.AvaliacaoTecnica.CrossCutting.Ioc;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectorContainer.Register(container);
        }
    }
}