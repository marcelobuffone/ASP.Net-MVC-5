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
    public class EntradaVeiculoController : Controller
    {
        private readonly IRegistroEntradaAppService _registroEntradaAppService;
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public EntradaVeiculoController(IRegistroEntradaAppService registroAppService
                                        , IVeiculoAppService veiculoAppService 
                                        , IUsuarioAppService usuarioAppService)
        {
            _registroEntradaAppService = registroAppService;
            _veiculoAppService = veiculoAppService;
            _usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            var GuidUsuarioLogado = Guid.Parse(User.Identity.GetUserId());
            var usuario = _usuarioAppService.ObterPorUserId(GuidUsuarioLogado).FirstOrDefault();
            return View(_registroEntradaAppService.ObterTodosPorEmpresa(usuario.EmpresaId).OrderByDescending(e => e.HoraEntrada));
        }

        private void RegistrarEntradaVeiculo(VeiculoViewModel veiculo)
        {
            var GuidUsuarioLogado = Guid.Parse(User.Identity.GetUserId());
            var _veiculo = veiculo;
            var _usuario = _usuarioAppService.ObterPorUserId(GuidUsuarioLogado).FirstOrDefault();

            var _register = new RegistroEntradaViewModel();
            _register.VeiculoId = _veiculo.Id;
            _register.EmpresaId = _usuario.EmpresaId;
            _register.Codigo = _veiculo.Placa + DateTime.Now.ToString().Replace("/", "").Replace("-", "").Replace(":", "").Replace(" ", "");
            _registroEntradaAppService.Adicionar(_register);

        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(VeiculoViewModel veiculo)
        {
            var _veiculo = _veiculoAppService.ObterPorPlaca(veiculo.Placa).FirstOrDefault();
            if (_veiculo == null)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMensager = "Veículo não registrada no sistema, deseja cadastra-lo?";
                return View();
            }
            else
            {
                RegistrarEntradaVeiculo(_veiculo);
                return RedirectToAction("Index");
            }

            
        }
    }
}