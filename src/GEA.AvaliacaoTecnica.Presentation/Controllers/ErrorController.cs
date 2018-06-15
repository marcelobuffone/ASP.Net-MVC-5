using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("Error");
        }
        public ActionResult NotFound()
        {
            return View("NotFound");
        }
        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}