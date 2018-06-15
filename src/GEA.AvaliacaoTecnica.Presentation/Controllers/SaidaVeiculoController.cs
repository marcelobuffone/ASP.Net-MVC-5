using GEA.AvaliacaoTecnica.Application.Interfaces;
using GEA.AvaliacaoTecnica.Application.ViewModels;
using GEA.AvaliacaoTecnica.Infra.CrossCutting.MvcFilters;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GEA.AvaliacaoTecnica.Presentation.Controllers
{
    [MyAuthorize(Roles = "Operario")]

    public class SaidaVeiculoController : Controller
    {
        private readonly IRegistroSaidaAppService _registroSaidaAppService;
        private readonly IRegistroEntradaAppService _registroEntradaAppService;
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public SaidaVeiculoController(IRegistroSaidaAppService registroAppService
                                      , IVeiculoAppService veiculoAppService
                                      , IUsuarioAppService usuarioAppService
                                      , IRegistroEntradaAppService registroEntradaAppService)
        {
            _registroSaidaAppService = registroAppService;
            _veiculoAppService = veiculoAppService;
            _usuarioAppService = usuarioAppService;
            _registroEntradaAppService = registroEntradaAppService;
        }
        public ActionResult Index()
        {
            var GuidUsuarioLogado = Guid.Parse(User.Identity.GetUserId());
            var usuario = _usuarioAppService.ObterPorUserId(GuidUsuarioLogado).FirstOrDefault();
            return View(_registroSaidaAppService.ObterTodosPorEmpresa(usuario.EmpresaId).OrderByDescending(e => e.HoraSaida));
        }

        public ActionResult Registrar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registrar(RegistroEntradaViewModel registroEntrada)
        {
            var registroCodigo = _registroEntradaAppService.ObterPorCodigo(registroEntrada.Codigo).FirstOrDefault();

            if (registroCodigo != null)
            {
                if (_registroSaidaAppService.ObterPorIdEntrada(registroCodigo.Id).Count() == 0)
                {
                    var totalMinutos = (DateTime.Now - registroCodigo.HoraEntrada).TotalMinutes;
                    var valor = totalMinutos * 0.13;
                    var registroSaida = new RegistroSaidaViewModel
                    {
                        RegistroEntradaId = registroCodigo.Id,
                        HoraSaida = DateTime.Now,
                        ValorTotal = Convert.ToSingle(valor.ToString("0.00"))
                    };
                    _registroSaidaAppService.Adicionar(registroSaida);
                    return RedirectToAction("Index");
                }
                ViewBag.Error = true;
                ViewBag.ErrorMensager = "Código já Utilizado.";
                return View();
            }

            ViewBag.Error = true;
            ViewBag.ErrorMensager = "Código Inválido.";
            return View();

        }
    }
}