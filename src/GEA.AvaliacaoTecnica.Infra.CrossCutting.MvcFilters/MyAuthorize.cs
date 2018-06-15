using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters
{
    public class MyAuthorize :AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
