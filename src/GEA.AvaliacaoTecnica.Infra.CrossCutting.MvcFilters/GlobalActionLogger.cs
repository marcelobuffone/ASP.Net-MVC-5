using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //log de erro
            //usuario, acao, ip, maquina
            if (filterContext.Exception != null)
            {
                //manipular ex
                //salvar erro
                //enviar email

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
