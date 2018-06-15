using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    [MyAuthorize(Roles ="Admin")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;
        private readonly ICompetenciaAbertaAppService _competenciaAbertaAppService;
        public EmpresaController(IEmpresaAppService empresaAppService, ICompetenciaAbertaAppService competenciaAbertaAppService)
        {
            _empresaAppService = empresaAppService;
            _competenciaAbertaAppService = competenciaAbertaAppService;
        }

        public ActionResult Index()
        {
            return View(_empresaAppService.ObterTodos().OrderByDescending(e => e.DataCadastro));
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(EmpresaViewModel empresa)
        {
            if(_empresaAppService.ObterPorRazaoSocial(empresa.RazaoSocial).FirstOrDefault() == null)
            {
                _empresaAppService.Adicionar(empresa);

                var dataVencimento = DateTime.Now;
                if (dataVencimento.Day < empresa.DiaVencimento)
                {
                    dataVencimento = new DateTime(dataVencimento.Year, dataVencimento.Month, empresa.DiaVencimento) + new TimeSpan(23,59,59);
                }else if(dataVencimento.Day >= empresa.DiaVencimento)
                {
                        dataVencimento = new DateTime(dataVencimento.AddMonths(1).Year, dataVencimento.AddMonths(1).Month, empresa.DiaVencimento) + new TimeSpan(23, 59, 59);
                }
                var competenciaAberta = new CompetenciaAberturaViewModel
                {
                    DataVencimento = dataVencimento,
                    EmpresaId = empresa.Id
                };
                _competenciaAbertaAppService.Adicionar(competenciaAberta);
                return RedirectToAction("Index");
            }

            ViewBag.Error = true;
            ViewBag.ErrorMensager = "Razão social já está sendo usada.";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _empresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
