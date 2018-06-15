using GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
